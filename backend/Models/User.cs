namespace backend.Models
{
    public class User
    {
        public int Id { get; set; } // PK
        public string EmpNo { get; set; } = string.Empty; // 로그인 ID (사원번호)
        public string Role { get; set; } = string.Empty;  // 권한 (Admin, Manager, Employee)
        public string PasswordHash { get; set; } = string.Empty; // 암호화된 비밀번호
    }
}
