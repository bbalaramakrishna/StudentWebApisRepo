using StudentInformation.Dto;

namespace StudentInformation.Interface
{
    public interface studentInterface
    {
        List<studentdto> studentdetails(int id);

        public int UpdateData(int id, string firstName);
        public int DeleteData(int Id);
        public int  InsertData(studentdto dtostudent);
    } 

}
