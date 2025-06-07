

string studentName;

string address = "Hà Nội, Việt Nam";


int studentAge;
studentAge = 22;

int seconds = 60;                    
double so_pi = 3.14;                 
bool deltaIsSezo = true;            
char chooseAction = 'S';            
string msgResult = "Kết quả giải:"; 

Console.WriteLine();                                               
Console.WriteLine();                                           

Console.ForegroundColor = ConsoleColor.DarkMagenta;                
Console.WriteLine("XIN CHÀO - CHƯƠNG TRÌNH NHẬP XUẤT DỮ LIỆU");    
Console.ResetColor();                                               

Console.Write("Giá trị biến so_pi là : ");                         
Console.WriteLine(so_pi);                                          
Console.WriteLine();                                                

int a = 123;
double b = 567.123;

Console.WriteLine("Biến a = {0}, biến b = {1}", a, b);

Console.WriteLine($"Biến a = {a}, biến b = {b} - tích là {a * b}");


// Input Data

string userLogin;
Console.Write("Nhập username : ");
userLogin = Console.ReadLine();
Console.WriteLine($"Tên nhập vào là: {userLogin}");

Console.Write("Nhập một số thực : ");
// Input string - convert string to number
double dinput = Convert.ToDouble(Console.ReadLine());
Console.WriteLine($"Số đã nhập là: {dinput}");


var bien1 = 3.14;
var bien2 = 3;
var bien3 = "Biến khai báo với var phải khởi tạo ngay";
var bien4 = (5 < 4);

const string MON = "THỨ HAI";
Console.WriteLine(MON);

