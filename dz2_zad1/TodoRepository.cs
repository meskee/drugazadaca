using System;
using System.Collections.Generic;
using System.Linq;

namespace dz2_zad1
{
    /// <summary>
    ///     Class that encapsulates all the logic for accessing TodoTtems .
    /// </summary>
    public class TodoRepository : ITodoRepository
    {
        private readonly List<TodoItem> _inMemoryTodoDatabase;

        /// <summary>
        ///     Repository does not fetch todoItems from the actual database ,
        ///     it uses in memory storage for this excersise .
        /// </summary>
        public TodoRepository(List<TodoItem> initialDbState = null)
        {
            _inMemoryTodoDatabase = initialDbState ?? new List<TodoItem>();
        }

        public TodoItem Get(Guid todoId)
        {
            return _inMemoryTodoDatabase.FirstOrDefault(i => i.Id == todoId);
        }

        public void Add(TodoItem todoItem)
        {
            if (todoItem == null) throw new ArgumentNullException();
            if (Equals(Get(todoItem.Id), todoItem)) throw new DuplicateTodoItemException();
            _inMemoryTodoDatabase.Add(todoItem);
        }

        public bool Remove(Guid todoId)
        {
            return _inMemoryTodoDatabase.Remove(Get(todoId));
        }

        public void Update(TodoItem todoItem)
        {
            if (Get(todoItem.Id) == null) Add(todoItem);
            else
            {
                var item = Get(todoItem.Id);
                item = todoItem;
            }
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            if (Get(todoId) == null) return false;
            var item = Get(todoId);
            item.MarkAsCompleted();
            return item.IsCompleted;
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.OrderByDescending(i => i.DateCreated).ToList();
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(i => !i.IsCompleted).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(i => i.IsCompleted).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(filterFunction).ToList();
        }

        public void Printf()
        {
            foreach (var item in _inMemoryTodoDatabase)
                Console.WriteLine("{0}, {1}, {2}, {3}", item.Id, item.Text, item.DateCreated, item.DateCompleted);
        }
    }
}
