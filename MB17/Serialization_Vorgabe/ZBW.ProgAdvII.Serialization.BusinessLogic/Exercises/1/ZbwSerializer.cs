using System;
using System.IO;

namespace ZBW.ProgAdvII.Serialization.BusinessLogic.Exercises._1
{
    public class ZbwSerializer : ISerializer
    {
        public void Serialize(Student student, Stream stream)
        {
            if (student is null || stream is null)
            {
                throw new ArgumentNullException();
            }

            


        }

        public Student Deserialize(Stream stream)
        {
            throw new NotImplementedException();
        }
    }
}