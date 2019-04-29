using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Test
{
    class Program
    {
        public static void Main(String[] args)
        {
            new Menu();
        }

    }
    class Menu
    {
        sql helper;
        public Menu()
        {
            helper = new sql();
            ManCargo();
            //MainMenu();
        }
        //主菜单
        public void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                gotoY(6);
                print("\t\t*****************************************\n");
                print("\t\t+         欢迎来到小型物流管理系统        +\n");
                print("\t\t+---------------------------------------+\n");
                print("\t\t+                                       +\n");
                print("\t\t+         1.部门主管                    +\n");
                print("\t\t+                                       +\n");
                print("\t\t+         2.退出                        +\n");
                print("\t\t+                                       +\n");
                print("\t\t*****************************************\n");
                print("\n\t\t          请输入您的选项:");
                int Ch = readInt();
                while (Ch == -1)
                {
                    print("\n\t\t          请重新输入选项：");
                    Ch = readInt();
                }
                switch (Ch)
                {
                    case 1:
                        Manager();
                        break;
                    case 2:
                        Environment.Exit(0);
                        break;
                    default:
                        print("\n\t\t          您的输入有错，请按任意键继续");
                        Console.ReadKey();
                        continue;
                }
            }
        }
        //管理员菜单
        public void Manager()
        {
            while (true)
            {
                Console.Clear();
                gotoY(6);
                print("\t\t*****************************************\n");
                print("\t\t+           部门主管界面                +\n");
                print("\t\t+---------------------------------------+\n");
                print("\t\t+\t 1.管理员工信息\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 2.管理客户信息\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 3.管理货物信息\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 4.返回上层菜单\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 5.退出系统   \t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t*****************************************\n");
                print("\n\t\t\t  请输入您的选项:");
                int Ch = readInt();
                while (Ch == -1)
                {
                    print("\n\t\t\t  请重新输入选项：");
                    Ch = readInt();
                }
                switch (Ch)
                {
                    case 1:
                        ManEmp();
                        break;
                    case 2:
                        ManCargo();
                        break;
                    case 3:
                        ManCus();
                        break;
                    case 4:
                        return;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        print("\n\t\t          您的输入有错，请按任意键继续");
                        Console.ReadKey();
                        break;
                }
            }
        }
        //管理员-员工管理
        public void ManEmp()
        {
            while (true)
            {
                Console.Clear();
                gotoY(6);
                print("\t\t*****************************************\n");
                print("\t\t+           管理员工信息                +\n");
                print("\t\t+---------------------------------------+\n");
                print("\t\t+\t 1.增加员工信息\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 2.删除员工信息\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 3.查找员工信息\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 4.修改员工信息\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 5.返回上层菜单\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 6.退出系统   \t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t*****************************************\n");
                print("\n\t\t\t  请输入您的选项:");
                int Ch = readInt();
                while (Ch == -1)
                {
                    print("\t\t\t  请重新输入选项：");
                    Ch = readInt();
                }
                switch (Ch)
                {
                    case 1:
                        Emp_add();
                        break;
                    case 2:
                        Emp_del();
                        break;
                    case 3:
                        Emp_find();
                        break;
                    case 4:
                        Emp_alter();
                        break;
                    case 5:
                        return;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        print("\n\t\t          您的输入有错，请按任意键继续");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void Emp_add()//添加员工
        {
            while (true)
            {
                print_title("员工管理", "添加员工");
                print("请按序输入员工的以下信息,每个信息占一行且所有信息均不能为空：\n工号，姓名，联系方式，权限\n");
                var no = Console.ReadLine();
                var name = Console.ReadLine();
                var tel = Console.ReadLine();
                var p1 = Console.ReadLine();
                int p = Convert.ToInt32(p1);
                if (check_null(new string[] { no, name, tel}))
                {
                    int operatorCode = helper.employee_add(no, name, tel, p);
                    if (operatorCode == 0)
                    {
                        print("添加成功，新增员工后所有员工信息如下：\n");
                        var emps = helper.find_all("employee");
                        print_emp(emps);
                    }
                    else
                    {
                        print_error(operatorCode);
                        Console.ReadKey();
                    }
                }
                else
                {
                    print("\n输入的值中存在某些值为空，请按任意键重新输入：");
                    Console.ReadKey();
                }
                print("\n是否继续添加，继续添加请按【1】，按其他任意键退出添加：");
                int cc = readInt();
                if (cc != 1 || cc == -1)
                {
                    break;
                }
            }
        }
        public void Emp_del()//删除员工
        {
            while (true)
            {
                print_title("员工管理", "删除员工");
                print("请选择您要删除的员工信息：");
                print("\n【1】根据编号删除员工\n");
                print("\n【2】退出删除\n");
                print("\n请输入您的选项：\n");
                int Ch = readInt();
                while (Ch == -1)
                {
                    print("\n您输入的选项有误，请重新输入选项：");
                    Ch = readInt();
                }
                int operatorCode;
                if (Ch == 1)
                {
                    print("请输入已辞职员工工号：\n");
                    string num = Console.ReadLine();
                    print_title("员工管理", "根据编号删除员工");
                    operatorCode = helper.del_no("employee", "emp_no", num);
                    if (operatorCode == 1)
                    {
                        print("删除失败，要删除的员工不存在\n");
                    }
                    else
                    {
                        print("删除成功，删除后的员工列表如下：\n");
                        var emps = helper.find_all("employee");
                        print_emp(emps);
                    }
                }
                else if (Ch == 2)
                {
                    break;
                }
                else
                {
                    print("\n您输入的选项不存在，按任意键重新输入：");
                    Console.ReadKey();
                    continue;
                }
                print("\n是否继续删除，继续删除请按【1】，按其他任意键退出删除：");
                int cc = readInt();
                if (cc != 1 || cc == -1)
                {
                    break;
                }
            }
        }
        public void Emp_find()//查找员工
        {
            while (true)
            {
                print_title("员工管理", "查找员工");
                print("请选择查找条件：\n【1】按照工号查找。\n【2】按员工名字查找（模糊查找，输入部分名字）\n【3】所有员工的信息\n【4】退出查找");
                print("\n请输入:");
                int Ch = readInt();
                while (Ch == -1)
                {
                    print("\n请重新输入选项：");
                    Ch = readInt();
                }
                if (Ch == 1)
                {
                    print("\n请输入要查找的员工的工号：");
                    string id = Console.ReadLine();
                    print_title("员工管理", "按工号查找员工");
                    var emps = helper.find_id("employee", "emp_no", id);
                    print_emp(emps);
                }
                else if (Ch == 2)
                {
                    print("\n请输入员工部分姓名：");
                    string name = Console.ReadLine();
                    print_title("员工管理", "按员工姓名查找员工");
                    var emps = helper.find_name("employee", "emp_name", name);
                    print_emp(emps);
                }
                else if (Ch == 3)
                {
                    var emps = helper.find_all("employee");
                    print_title("员工管理", "查找所有员工");
                    print_emp(emps);
                }
                else if (Ch == 4)
                {
                    break;
                }
                else
                {
                    print("\n您输入的选项不存在，请按任意键重新输入：");
                    Console.ReadKey();
                    continue;

                }
                print("\n是否继续查找，继续查找请按【1】，按其他任意键退出查找：");
                int cc = readInt();
                if (cc != 1 || cc == -1)
                {
                    break;
                }
            }
        }
        public void Emp_alter()//修改员工信息
        {
            while (true)
            {
                print_title("员工管理", "修改员工信息");
                print("所有员工信息如下：\n");
                var emps = helper.find_all("employee");
                print_emp(emps);
                print("\n请输入您要修改信息的员工的工号:");
                var id = Console.ReadLine();
                emps = helper.find_id("employee", "emp_no", id);
                if (emps.Count() == 0)
                {
                    print("\n您输入的员工编号有误，请按任意键继续：");
                    Console.ReadKey();
                    continue;
                }
                print("\n请选择要修改的员工的信息:\n1.姓名    2.联系方式    3.权限    4.退出修改\n");
                print("\n请输入您的选项：");
                int Ch = readInt();
                while (Ch == -1)
                {
                    print("\n请重新输入选项：");
                    Ch = readInt();
                }
                String edit;
                int ty;
                switch (Ch)
                {
                    case 1:
                        print("请输入修改后的员工的姓名：\n");
                        ty = 0;
                        break;
                    case 2:
                        print("请输入修改后的员工的联系方式：\n");
                        ty = 0;
                        break;
                    case 3:
                        print("请输入修改后的员工的权限：\n");
                        ty = 1;
                        break;
                    case 4:
                        return;
                    default:
                        print("\n您输入的选项不存在，按任意键重新开始修改：");
                        Console.ReadKey();
                        continue;
                }
                edit = Console.ReadLine();
                if ((check_null(new string[] { id })) && (check_null(new string[] { edit })))
                {
                    helper.employee_alter(id, Ch, edit, ty);
                }
                else if (check_null(new string[] { edit }))
                {
                    print("\n您输入的员工编号为空，请按任意键继续：");
                    Console.ReadKey();
                    continue;
                }
                else if (check_null(new string[] { id }))
                {
                    print("\n您输入的修改后的信息为空，请按任意键继续：");
                    Console.ReadKey();
                    continue;
                }
                print("修改后的信息如下:\n");
                emps = helper.find_id("employee", "emp_no", id);
                print_emp(emps);
                print("\n是否继续修改，继续修改请按【1】，按其他任意键退出修改：");
                int cc = readInt();
                if (cc != 1 || cc == -1)
                {
                    break;
                }
            }
        }
        //管理员-货物管理
        public void ManCargo()
        {
            while (true)
            {
                Console.Clear();
                gotoY(6);
                print("\t\t*****************************************\n");
                print("\t\t+           管理货物信息                +\n");
                print("\t\t+---------------------------------------+\n");
                print("\t\t+\t 1.增加货物信息\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 2.删除货物信息\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 3.查找货物信息\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 4.修改货物信息\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 5.返回上层菜单\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 6.退出系统   \t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t*****************************************\n");
                print("\n\t\t\t  请输入您的选项:");
                int Ch = readInt();
                while (Ch == -1)
                {
                    print("\n\t\t\t  请重新输入选项：");
                    Ch = readInt();
                }
                switch (Ch)
                {
                    case 1:
                        Cargo_add();
                        break;
                    case 2:
                        Cargo_del();
                        break;
                    case 3:
                        Cargo_find();
                        break;
                    case 4:
                        Cargo_alter();
                        break;
                    case 5:
                        return;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        print("\n\t\t\t  您的输入有错，请按任意键继续");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void Cargo_add()//增加货物信息
        {
            while (true)
            {
                print_title("货物管理", "增加货物信息");
                print("请选择您要删除的员工信息：");
                print("\n【1】增加货物\n");
                print("\n【2】增加货物运送状态\n");
                print("\n【3】退出删除\n");
                print("\n请输入您的选项：\n");
                int Ch = readInt();
                while (Ch == -1)
                {
                    print("\n您输入的选项有误，请重新输入选项：");
                    Ch = readInt();
                }
                if (Ch == 1)
                {
                    cargo_add();
                }
                else if (Ch == 2)
                {
                    cargo_p_add();
                }
                else if (Ch == 3)
                {
                    break;
                }
                else
                {
                    print("\n您输入的选项不存在，按任意键重新输入：");
                    Console.ReadKey();
                    continue;
                }
                print("\n是否继续删除，继续删除请按【1】，按其他任意键退出删除：");
                int cc = readInt();
                if (cc != 1 || cc == -1)
                {
                    break;
                }
            }
        }
        public void cargo_add()//增加货物
        {
            while (true)
            {
                print_title("货物管理", "增加货物");
                print("请按序输入货物的以下信息,且每个信息占一行：\n编号，客号，员号，状态，始发地，目的地\n");
                var car_no = Console.ReadLine();
                var cus_no = Console.ReadLine();
                var emp_no = Console.ReadLine();
                var car_status1 = Console.ReadLine();
                var car_f = Console.ReadLine();
                var car_t = Console.ReadLine();
                int car_status = Convert.ToInt32(car_status1);
                if (check_null(new string[] { car_no, cus_no, emp_no, car_status1, car_f, car_t }))
                {
                    int operatorCode = helper.cargo_add(car_no, cus_no, emp_no,car_status, car_f, car_t);
                    if (operatorCode == 0)
                    {
                        print("添加成功，新增货物后所有货物信息如下：\n\n");
                        var cars = helper.find_all("cargo");
                        print_car(cars);
                    }
                    else
                    {
                        print_error(operatorCode);
                        Console.ReadKey();
                    }
                }
                else
                {
                    print("\n输入的值中存在某些值为空，请按任意键重新输入：");
                    Console.ReadKey();
                }
                print("\n是否继续添加，继续添加请按【1】，按其他任意键退出添加：");
                int cc = readInt();
                if (cc != 1 || cc == -1)
                {
                    break;
                }
            }
        }
        public void cargo_p_add()//增加货物状态信息
        {
            while (true)
            {
                print_title("货物管理", "增加货物状态信息");
                print("请按序输入货物的以下信息,且每个信息占一行：\n编号，到达地，时间，员工编号\n");
                var car_no = Console.ReadLine();
                var car_adv = Console.ReadLine();
                var time1 = Console.ReadLine();
                var emp_no = Console.ReadLine();
                DateTime time = Convert.ToDateTime(time1);
                if (check_null(new string[] { car_no, car_adv,time1, emp_no }))
                {
                    int operatorCode = helper.cargo_p_add(car_no, car_adv, time, emp_no);
                    if (operatorCode == 0)
                    {
                        print("添加成功，新增货物后所有货物信息如下：\n\n");
                        var cars = helper.find_all("cargo");
                        print_car_p(cars);
                    }
                    else
                    {
                        print_error(operatorCode);
                        Console.ReadKey();
                    }
                }
                else
                {
                    print("\n输入的值中存在某些值为空，请按任意键重新输入：");
                    Console.ReadKey();
                }
                print("\n是否继续添加，继续添加请按【1】，按其他任意键退出添加：");
                int cc = readInt();
                if (cc != 1 || cc == -1)
                {
                    break;
                }
            }
        }
        public void Cargo_del()//删除货物信息
        {
            while (true)
            {
                print_title("货物管理", "删除货物");
                print("所有货物信息如下\n");
                var cars = helper.find_all("cargo");
                print_car(cars);
                int operatorCode;
                print("请输入要删除的货物编号：\n");
                string num = Console.ReadLine();
                operatorCode = helper.del_no("cargo", "car_no", num);
                if (operatorCode == 1)
                {
                    print("删除失败，要删除的货物不存在\n");
                }
                else
                {
                    print("删除成功，删除后的货物列表如下：\n");
                    cars = helper.find_all("cargo");
                    print_car(cars);
                }
                print("\n是否继续删除，继续删除请按【1】，按其他任意键退出删除：");
                int cc = readInt();
                if (cc != 1 || cc == -1)
                {
                    break;
                }
            }
        }
        public void Cargo_find()//查找货物信息
        {
            while (true)
            {
                print_title("货物管理", "查找货物");
                print("请选择查找条件：\n【1】按照货号查找。\n【2】按员工编号查找\n【3】所有货物的信息\n【4】指定货物路径信息\n【5】退出查找");
                print("\n请输入:");
                int Ch = readInt();
                while (Ch == -1)
                {
                    print("\n请重新输入选项：");
                    Ch = readInt();
                }
                if (Ch == 1)
                {
                    print("\n请输入要查找的货物的编号：");
                    string id = Console.ReadLine();
                    print_title("货物管理", "按货号查找货物");
                    var cars = helper.find_id("cargo", "car_no", id);
                    print_car(cars);
                }
                else if (Ch == 2)
                {
                    print("\n请输入员工编号：");
                    string emp_no = Console.ReadLine();
                    print_title("货物", "按货物名称查找货物");
                    var cars = helper.find_id("cargo", "emp_no", emp_no);
                    print_car(cars);
                }
                else if (Ch == 3)
                {
                    var cars = helper.find_all("cargo");
                    print_title("货物管理", "查找所有货物");
                    print_car(cars);
                }
                else if (Ch == 4)
                {
                    print("\n请输入货物编号：");
                    string car_no = Console.ReadLine();
                    print_title("货物", "指定货物状态查找");
                    var cars = helper.find_cargo_p(car_no);
                    print_car(cars);
                }
                else if (Ch == 5)
                {
                    break;
                }
                else
                {
                    print("\n您输入的选项不存在，请按任意键重新输入：");
                    Console.ReadKey();
                    continue;

                }
                print("\n是否继续查找，继续查找请按【1】，按其他任意键退出查找：");
                int cc = readInt();
                if (cc != 1 || cc == -1)
                {
                    break;
                }
            }
        }
        public void Cargo_alter()
        {
            while (true)
            {
                print_title("货物管理", "修改货物信息");
                print("所有货物信息如下：\n");
                var cars = helper.find_all("cargo");
                print_car(cars);
                print("\n请输入您要修改信息的货物的编号:");
                var id = Console.ReadLine();
                cars = helper.find_id("cargo", "car_no", id);
                if (cars.Count() == 0)
                {
                    print("\n您输入的货物编号有误，请按任意键继续：");
                    Console.ReadKey();
                    continue;
                }
                print("请选择要修改的的信息:\n1.货物状态\t2.退出修改\n");
                print("\n请输入您的选项：");
                int Ch = readInt();
                while (Ch == -1)
                {
                    print("\n请重新输入选项：");
                    Ch = readInt();
                }
                int ty;
                int edit;
                switch (Ch)
                {
                    case 1:
                        ty = 0;
                        edit = 1;
                        break;                  
                    case 2:
                        return;
                    default:
                        print("\n您输入的选项不存在，按任意键重新开始修改：");
                        Console.ReadKey();
                        continue;
                }
                if ((check_null(new string[] { id })))
                {   
                    helper.cargo_alter(id, edit,Ch, ty);
                }
                else
                {
                    print("\n您输入的货物编号为空，请按任意键继续：");
                    Console.ReadKey();
                    continue;
                }
                print("修改后的信息如下:\n");
                cars = helper.find_id("cargo", "car_no", id);
                print_car(cars);
                print("\n是否继续修改，继续修改请按【1】，按其他任意键退出修改：");
                int cc = readInt();
                if (cc != 1 || cc == -1)
                {
                    break;
                }
            }
        }
        //管理员-客户管理
        public void ManCus()
        {
            while (true)
            {
                Console.Clear();
                gotoY(6);
                print("\t\t*****************************************\n");
                print("\t\t+           管理员工信息                +\n");
                print("\t\t+---------------------------------------+\n");
                print("\t\t+\t 1.增加客户信息\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 2.删除客户信息\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 3.查找客户信息\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 4.修改客户信息\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 5.返回上层菜单\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 6.退出系统   \t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t*****************************************\n");
                print("\n\t\t\t  请输入您的选项:");
                int Ch = readInt();
                while (Ch == -1)
                {
                    print("\t\t\t  请重新输入选项：");
                    Ch = readInt();
                }
                switch (Ch)
                {
                    case 1:
                        Cus_add();
                        break;
                    case 2:
                        Cus_del();
                        break;
                    case 3:
                        Cus_find();
                        break;
                    case 4:
                        Cus_alter();
                        break;
                    case 5:
                        return;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        print("\n\t\t          您的输入有错，请按任意键继续");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void Cus_add()//添加客户
        {
            while (true)
            {
                while (true)
                {
                    print_title("销售员", "添加客户");
                    print("请按序输入客户的以下信息,且每个信息占一行：\n编号，姓名，电话，住址\n");
                    var cust_no = Console.ReadLine();
                    var name = Console.ReadLine();
                    var tel = Console.ReadLine();
                    var addr = Console.ReadLine();
                    if (check_null(new string[] { cust_no, name, tel, addr }))
                    {
                        int operatorCode = helper.customer_add(cust_no, name, tel, addr);
                        if (operatorCode == 0)
                        {
                            print("添加成功，新增客户后所有客户信息如下：\n");
                            var custs = helper.find_all("customer");
                            print_cust(custs);
                        }
                        else
                        {
                            print_error(operatorCode);
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        print("\n输入的值中存在某些值为空，请按任意键重新输入：");
                        Console.ReadKey();
                    }
                    print("\n是否继续添加，继续添加请按【1】，按其他任意键退出添加：");
                    int cc = readInt();
                    if (cc != 1 || cc == -1)
                    {
                        break;
                    }                 
                }
                break;
            }
        }
        public void Cus_del()//删除客户
        {
            while (true)
            {
                print_title("员工管理", "删除员工");
                print("请选择您要删除的员工信息：");
                print("\n【1】根据编号删除客户\n");
                print("\n【2】退出删除\n");
                print("\n请输入您的选项：\n");
                int Ch = readInt();
                while (Ch == -1)
                {
                    print("\n您输入的选项有误，请重新输入选项：");
                    Ch = readInt();
                }
                int operatorCode;
                if (Ch == 1)
                {
                    print("请输入客户编号：\n");
                    string num = Console.ReadLine();
                    print_title("客户管理", "根据编号删除客户");
                    operatorCode = helper.del_no("customer", "cus_no", num);
                    if (operatorCode == 1)
                    {
                        print("删除失败，要删除的客户不存在\n");
                    }
                    else
                    {
                        print("删除成功，删除后的客户列表如下：\n");
                        var custs = helper.find_all("customer");
                        print_cust(custs);
                    }
                }
                else if (Ch == 2)
                {
                    break;
                }
                else
                {
                    print("\n您输入的选项不存在，按任意键重新输入：");
                    Console.ReadKey();
                    continue;
                }
                print("\n是否继续删除，继续删除请按【1】，按其他任意键退出删除：");
                int cc = readInt();
                if (cc != 1 || cc == -1)
                {
                    break;
                }
            }
        }
        public void Cus_find()//查找客户
        {
            while (true)
            {
                print_title("客户管理", "客户员工");
                print("请选择查找条件：\n【1】按照客号查找。\n【2】按客户名字查找（模糊查找，输入部分名字）\n【3】所有客户的信息\n【4】退出查找");
                print("\n请输入:");
                int Ch = readInt();
                while (Ch == -1)
                {
                    print("\n请重新输入选项：");
                    Ch = readInt();
                }
                if (Ch == 1)
                {
                    print("\n请输入要查找的客户的客号：");
                    string id = Console.ReadLine();
                    print_title("客户管理", "按客号查找客户");
                    var custs = helper.find_id("customer", "cus_no", id);
                    print_cust(custs);
                }
                else if (Ch == 2)
                {
                    print("\n请输入客户部分姓名：");
                    string name = Console.ReadLine();
                    print_title("客户管理", "按客户姓名查找客户");
                    var custs = helper.find_name("customer", "cus_name", name);
                    print_cust(custs);
                }
                else if (Ch == 3)
                {
                    var custs = helper.find_all("customer");
                    print_title("客户管理", "查找所有客户");
                    print_cust(custs);
                }
                else if (Ch == 4)
                {
                    break;
                }
                else
                {
                    print("\n您输入的选项不存在，请按任意键重新输入：");
                    Console.ReadKey();
                    continue;

                }
                print("\n是否继续查找，继续查找请按【1】，按其他任意键退出查找：");
                int cc = readInt();
                if (cc != 1 || cc == -1)
                {
                    break;
                }
            }
        }
        public void Cus_alter()//修改客户信息
        {
            while (true)
            {
                print_title("客户管理", "修改客户信息");
                print("所有客户信息如下：\n");
                var custs = helper.find_all("customer");
                print_cust(custs);
                print("\n请输入您要修改信息的客户的客号:");
                var id = Console.ReadLine();
                custs = helper.find_id("customer", "cus_no", id);
                if (custs.Count() == 0)
                {
                    print("\n您输入的客户编号有误，请按任意键继续：");
                    Console.ReadKey();
                    continue;
                }
                print("\n请选择要修改的客户的信息:\n1.姓名    2.联系方式    3.地址    4.退出修改\n");
                print("\n请输入您的选项：");
                int Ch = readInt();
                while (Ch == -1)
                {
                    print("\n请重新输入选项：");
                    Ch = readInt();
                }
                String edit;
                int ty;
                switch (Ch)
                {
                    case 1:
                        print("请输入修改后的客户的姓名：\n");
                        ty = 0;
                        break;
                    case 2:
                        print("请输入修改后的客户的联系方式：\n");
                        ty = 0;
                        break;
                    case 3:
                        print("请输入修改后的客户的地址：\n");
                        ty = 0;
                        break;
                    case 4:
                        return;
                    default:
                        print("\n您输入的选项不存在，按任意键重新开始修改：");
                        Console.ReadKey();
                        continue;
                }
                edit = Console.ReadLine();
                if ((check_null(new string[] { id })) && (check_null(new string[] { edit })))
                {
                    helper.customer_alter(id, Ch, edit, ty);
                }
                else if (check_null(new string[] { edit }))
                {
                    print("\n您输入的客户编号为空，请按任意键继续：");
                    Console.ReadKey();
                    continue;
                }
                else if (check_null(new string[] { id }))
                {
                    print("\n您输入的修改后的信息为空，请按任意键继续：");
                    Console.ReadKey();
                    continue;
                }
                print("修改后的信息如下:\n");
                custs = helper.find_id("customer", "cus_no", id);
                print_cust(custs);
                print("\n是否继续修改，继续修改请按【1】，按其他任意键退出修改：");
                int cc = readInt();
                if (cc != 1 || cc == -1)
                {
                    break;
                }
            }
        }
       

        //打印及附属函数
        public int readInt()
        {
            int Ch;
            try
            {
                Ch = Int32.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {

                return -1;
            }
            return Ch;
        }
        public float readFloat()
        {
            float x;
            try
            {
                x = float.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {

                return -1;
            }
            return x;
        }
        public bool check_null(string[] s)
        {
            foreach (var i in s)
            {
                if (i == null || i.Length == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public void gotoY(int y)
        {
            for (int i = 0; i < y; i++)
            {
                print("\n");
            }
        }
        public void print(string s)
        {
            Console.Write(s);
        }
        public void print_title(string s1, string s2)
        {
            Console.Clear();
            gotoY(2);
            print(s1);
            print("--->");
            print(s2);
            print("\n————————————————————————————————\n");
        }
        public void print_car_p(DataRow[] emps)//打印货物状态
        {
            if (emps.Count() == 0)
            {
                print("没有您要的信息");
            }
            else
            {
                print("货号\t\t到达地\t\t时间\t员号\n");
                foreach (var r in emps)
                {
                    print(r["car_no"].ToString() + "\t" + r["car_adv"].ToString() + "\t" + r["time"].ToString() + "\t" + r["emp_no"].ToString() + "\n");
                }
            }
        }
        public void print_car(DataRow[] cars)//打印货物信息
        {
            if (cars.Count() == 0)
            {
                print("没有您要的信息");
            }
            else
            {
                print("货号\t\t客号\t\t员号\t\t状态\t始发\t\t目的\n");
                foreach (var r in cars)
                {
                    print(r["car_no"].ToString() + "\t" + r["cus_no"].ToString() + "\t" + r["emp_no"].ToString() + "\t" + r["car_status"].ToString() + "\t" + r["car_f"].ToString() + r["car_t"].ToString() + "\n");
                }
            }
        }
        public void print_cust(DataRow[] custs)//打印客户信息
        {
            if (custs.Count() == 0)
            {
                print("没有您要的信息");
            }
            else
            {
                print("客户编号\t姓名\t\t\t电话号码\t\t住址\t\n");
                foreach (var r in custs)
                {
                    print(r["cus_no"].ToString() + "\t" + r["cus_name"].ToString()  + r["cus_tel"].ToString() + "\t" + r["ad"].ToString() + "\n");
                }
            }
        }
        public void print_emp(DataRow[] empsals)//打印员工信息
        {
            if (empsals.Count() == 0)
            {
                print("没有您要的信息");
            }
            else
            {
                print("员工编号\t员工姓名\t\t联系方式\t权限\n");
                foreach (var r in empsals)
                {
                    print(r["emp_no"].ToString() + "\t" + r["emp_name"].ToString() + r["emp_tel"].ToString() + r["emp_permission"].ToString() + "\n");
                }
            }
        }
        public void print_error(int operatorCode)
        {
            if (operatorCode == 2)
            {
                print("\n主码已存在，请按任意键重新输入:");
            }
            else if (operatorCode == 3)
            {
                print("\n主码不能为空，请按任意键重新输入:");
            }
            else if (operatorCode == 4)
            {
                print("\n输入中存在某些值不符合约束，请按任意键重新输入：");
            }
            else if (operatorCode == 5)
            {
                print("\n列名或所提供值的数目与表定义不匹配，请按任意键重新输入：");
            }
            else if (operatorCode == 6)
            {
                print("\n插入数据时有语法错误，请按任意键重新输入:");
            }
            else if (operatorCode == 7)
            {
                print("\n插入的数据中有非法值，请按任意键重新输入:");
            }
            else if (operatorCode == 8)
            {
                print("\n插入的数据中时间不合法，请按任意键重新输入:");
            }
            else if (operatorCode == 1)
            {
                print("\n没有任何行受影响，请按任意键重新输入：");
            }
        }
    }
    class sql
    {
        private SqlConnection connection;

        public sql()
        {
            initSqlConnection();
        }

        private void initSqlConnection()//与数据库连接
        {

            connection = new SqlConnection();

            String SqlIP = "127.0.0.1";//本地SQL服务器地址

            String InstanceName = "SQLEXPRESS";//SQL实例名

            String DateBaseName = "wl_cp";//数据库名称

            String UserName = "MuYi41";//登录用户名

            String PassWord = "970814";//登录密码

            //写入连接所使用的字符串信息

            connection.ConnectionString = String.Format("server = {0}\\{1}; database = {2}; uid = {3}; pwd = {4}", SqlIP, InstanceName, DateBaseName, UserName, PassWord);
        }

        //在数据库增加信息
        public int employee_add(string no, string name,string tel,int p)
        {
            String insertSql = $"INSERT INTO employee VALUES ('{no}', '{name}','{tel}',{p})";
            return ExecuteNonQuery(insertSql);
        }
        public int customer_add(string no, string name, string tel, string ad)
        {
            String insertSql = $"INSERT INTO customer VALUES ('{no}', '{name}','{tel}','{ad}')";
            return ExecuteNonQuery(insertSql);
        }
        public int cargo_add(string car_no, string cus_no, string emp_no, int car_status, string car_f, string car_t)
        {
            String insertSql = $"INSERT INTO cargo VALUES('{car_no}','{cus_no}',  '{emp_no}',{car_status}, '{car_f}', '{car_t}')";
            return ExecuteNonQuery(insertSql);
        }
        public int cargo_p_add(string car_no, string car_adv, DateTime time, string emp_no)//？有疑问
        {

            String insertSql = $"INSERT INTO customer VALUES('{car_no }', '{car_adv}','{time}','{emp_no}')";
            return ExecuteNonQuery(insertSql);
        }
        public int token_add(string emp_no, string device_id,string token, DateTime time, string refresh_token)//？有疑问
        {
            String insertSql = $"INSERT INTO customer VALUES('{emp_no }', '{device_id}','{token}','{time}','{refresh_token}')";
            return ExecuteNonQuery(insertSql);
        }

        //删除数据库中相应表的信息
        public int del_no(string s, string sn, string num)
        {
            String deleteSql = $"DELETE FROM {s} WHERE {sn} LIKE '{num}'";
            return ExecuteNonQuery(deleteSql);
        }

        //查找
        public DataRow[] find_all(string s)
        {
            String querySql = $"SELECT * FROM {s}";
            return ExecutQuery(querySql);
        }
        public DataRow[] find_id(string s, string sn, string id)
        {
            String querySql = $"SELECT * FROM {s} WHERE {sn} LIKE '{id}'";
            return ExecutQuery(querySql);
        }
        public DataRow[] find_cargo_p(string id)
        {
            String querySql = $"SELECT * FROM cargo_p WHERE car_no LIKE '{id}' ORDER BY time";
           return ExecutQuery(querySql);
        }
        public DataRow[] find_name(string s, string sn, string name)
        {
            StringBuilder bu = new StringBuilder();
            bu.Append("%");
            foreach (var c in name)
            {
                if (c == ' ')
                {
                    continue;
                }
                bu.Append(c);
                bu.Append("%");
            }
            name = bu.ToString();
            String querySql = $"SELECT * FROM {s} WHERE {sn} LIKE '{name}'";
            return ExecutQuery(querySql);
        }

        //修改数据库中信息
        public void employee_alter(string no, int Ch, string edit,int ty)
        {
            if (ty == 0)
                edit = $"'{edit}'";
            String[] na = new string[] { "emp_name", "emp_tel", "emp_permission" };//一次改这些权限中的一个权限
            String alterSql = $"UPDATE employee SET {na[Ch - 1]} = {edit} WHERE emp_no = '{no}'";
            ExecuteNonQuery(alterSql);
        }
        public void customer_alter(string no, int Ch, string edit,int ty)
        {
            if (ty == 0)
                edit = $"'{edit}'";
            String[] na = new string[] { "cus_name", "cus_tel", "ad" };
            String alterSql = $"UPDATE customer SET {na[Ch - 1]} = {edit} WHERE cus_no = '{no}'";
            ExecuteNonQuery(alterSql);
        }
        public void cargo_alter(string no, int edit, int Ch,int ty)
        {
            if (ty == 0)
                edit = $"{edit}";
            String alterSql = $"UPDATE customer SET car_status = {edit} WHERE car_no = '{no}'";//？？测试一下
            ExecuteNonQuery(alterSql);
        }
        
        private DataRow[] ExecutQuery(string s)
        {
            connection.Open();
            //构造一个接收数据的容器
            DataTable dt = new DataTable();
            //构造一个数据适配器
            SqlDataAdapter adapter = new SqlDataAdapter(s, connection);
            //发起查询，并把数据填充到dt中
            adapter.Fill(dt);
            //dt是一个结果集，本身不能去遍历它，我们通过Select方法取出行的数组
            DataRow[] data = dt.Select();
            connection.Close();
            return data;
        }

        private int ExecuteNonQuery(string s)//根据错误代码得出相应错误
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(s, connection);
            int delLen = 0;
            int operatorCode = 0;
            try
            {
                delLen = cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.Write(e);
                if (e.Number == 2627)//主码已存在
                {
                    operatorCode = 2;
                }
                if (e.Number == 515)//主码为空
                {
                    operatorCode = 3;
                }
                if (e.Number == 547)//不符合约束
                {
                    operatorCode = 4;
                }
                if (e.Number == 213)//列名或所提供值的数目与表定义不匹配
                {
                    operatorCode = 5;
                }
                if (e.Number == 102)//插入数据时有语法错误。
                {
                    operatorCode = 6;
                }
                if (e.Number == 207)//输入的值非法
                { 
                    operatorCode = 7;
                }
                if (e.Number == 242)//输入的时间不合法
                {
                    operatorCode = 8;
                }
            }
            connection.Close();
            if (operatorCode == 0 && delLen == 0)//受影响行数为0
            {
                operatorCode = 1;
            }
            return operatorCode;
        }
    }
}


