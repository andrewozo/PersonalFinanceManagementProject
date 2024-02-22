namespace PersonalFinanceManagementProject.Models
{
    public class Report<T>
    {
        public int Id { get; set; }

        public T? Data { get; set; }


    }
}
