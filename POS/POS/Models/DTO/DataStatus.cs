namespace POS.Models.DTO
{
    public class DataStatus<T>
    {
        public T Data { get; set; }
        public bool status { get; set; }
        public string Message { get; set; }
    }
}
