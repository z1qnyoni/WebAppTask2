public class Resident
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PersonalCode { get; set; }
    public DateTime BirthDate { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public bool IsOwner { get; set; }

    public List<Apartment> Apartments { get; set; } = new();
}
