namespace WebApplication4.DTO
{
    public class ApartmentDTO
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int Floor { get; set; }
        public int RoomCount { get; set; }
        public int ResidentCount { get; set; }
        public double TotalArea { get; set; }
        public double LivingArea { get; set; }

        public int HouseId { get; set; }
     
    }
}
