using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.IO;

namespace serialization
{
    public class Program
    {
        public byte[] CompressJson(string studentData)
        {
            //2.
            var studentObject = JsonConvert.DeserializeObject(studentData);
            //3.
            var jsonSerializer = new JsonSerializer();
            //4.
            var objBsonMemoryStream = new MemoryStream();
            //5.
            var bsonWriterObject = new BsonWriter(objBsonMemoryStream);
            //6.
            jsonSerializer.Serialize(bsonWriterObject, studentObject);

            return objBsonMemoryStream.ToArray();
        }

        public string DeCompressJson(byte[] compress_bytes)
        {
            var jsonSerializer = new JsonSerializer();
            //4.
            var objBsonMemoryStream = new MemoryStream(compress_bytes);
            //5.
            var bsonReaderObject = new BsonReader(objBsonMemoryStream);
            //6.
            var _result = jsonSerializer.Deserialize(bsonReaderObject);

            return _result.ToString();
        }

        public static void Main(string[] args)
        {
            var _p = new Program();

            //1.
            string studentData = @"{
                            'StudentId':'1',
                            'SyudentName':'MS',
                            'AcadmicYear':'First',
                            'Courses':[
                                        {'CourseId':'101','CourseName':'Compiler Design'},
                                        {'CourseId':'101','CourseName':'Compiler Design'}
                                      ]
                }";

            var _zip = _p.CompressJson(studentData);
            var _unzip = _p.DeCompressJson(_zip);

            Console.WriteLine(_unzip);
            Console.ReadLine();
        }
    }
}
