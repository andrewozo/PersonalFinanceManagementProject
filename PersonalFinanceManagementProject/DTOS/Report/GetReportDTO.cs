namespace PersonalFinanceManagementProject.DTOS.Report
{
    public class GetReportDTO<T>
    {
        public int Id { get; set; }

        public T? Data { get; set; }
    }
}
