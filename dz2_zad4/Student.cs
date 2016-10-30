using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2_zad4
{
  public class Student
    {
        public Student (string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public Student (string name, string jmbag, Gender gender)
        {
            Name = name;
            Jmbag = jmbag;
            Gender = gender;
        }

        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }

        public override bool Equals(object obj)
        {
            var stu = obj as Student;
            if ((bool)(stu == null)) return false;
            return stu.Jmbag.Equals(Jmbag);
        }

        public override int GetHashCode()
        {
            return Jmbag.GetHashCode();
        }

        public static object operator ==(Student A, Student B)
        {
            if (ReferenceEquals(A, null))
            {
                return ReferenceEquals(B, null);
            }
            return A.Equals(B);
        }

        public static object operator !=(Student A, Student B)
        {
            return !Equals(A, B);
        }

        public override string ToString()
        {
            return $" {Name} \t({Jmbag} : {Gender})"; 
        }
    }

    public enum Gender
    {
        Male, Female
    }


}
