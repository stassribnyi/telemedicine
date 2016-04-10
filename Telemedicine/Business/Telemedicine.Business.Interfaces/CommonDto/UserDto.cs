namespace Telemedicine.Business.Interfaces.CommonDto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronimic { get; set; }
        public string Phone { get; set; }
        public bool IsArchive { get; set; }
    }
}
