namespace PersonalFinanceManagementProject.DTOS.Account
{
    public class AddAccountDto
    {   
        public string Name { get; set; } = string.Empty;

        public decimal Balance { get; set; }
    }
}
