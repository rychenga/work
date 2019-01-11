----------------------------------------------
--2018/03/26
--[oracle]
http://127.0.0.1:8080/apex/f?p=4950:1:2429849603166661
--------------------------------------------------------------------------
CREATE TABLESPACE TBS
datafile 'C:\oraclexe\app\oracle\oradata\XE\TBS.dbf' SIZE 10M;
--------------------------------------------------------------------------
create TABLESPACE TBS
datafile 'C:\oraclexe\app\oracle\oradata\XE\TBS.dbf' SIZE 10M
 AUTOEXTEND ON
    NEXT 10M
    MAXSIZE 1000M;
--------------------------------------------------------------------------
create TABLESPACE TBS
datafile 'C:\oraclexe\app\oracle\oradata\XE\TBS.dbf' SIZE 10M
 AUTOEXTEND ON
    NEXT 1000M
    MAXSIZE 10000M;
--------------------------------------------------------------------------

SELECT A.STOCK_NAME,A.NAME,COUNT(*) CN
FROM LEGAL A,I_TRUST B
WHERE A.STOCK_NAME = B.STOCK_NAME
AND A.PRICE=B.PRICE
AND A.TYPE=B.TYPE
AND A.DAY = B.DAY
AND A.TYPE = 'BUY'
AND A.SHEETS > 5000
AND A.CHANGE > 0
AND A.DAY >= SYSDATE -14
GROUP BY A.STOCK_NAME,A.NAME
ORDER BY CN

SELECT *
FROM LEGAL A,I_TRUST B
WHERE  A.STOCK_NAME = B.STOCK_NAME
AND A.NAME = B.NAME
AND A.PRICE=B.PRICE
AND A.TYPE=B.TYPE
AND A.DAY = B.DAY
AND A.TYPE = 'BUY'
AND A.STOCK_NAME = '2317'
AND A.DAY >= SYSDATE -14
ORDER BY A.DAY


select t1.*,t2.sheets,t2.type,t3.sheets,t3.type 
from LEGAL t1,I_TRUST t2,DEALERS t3
where t1.stock_name = t2.stock_name
and t2.stock_name = t3.stock_name
and t1.price =t2.price
and t1.price = t3.price
and t1.day =t2.day
and t1.day = t3.day
and t1.change > 0
AND t1.DAY >= SYSDATE -7
order by t1.stock_name,t1.day


----------------------------------------
select T1.NAME
from I_TRUST t1,LEGAL T2
WHERE T1.DAY = T2.DAY
AND T1.TYPE = T2.TYPE
AND T1.NAME = T2.NAME
AND T1.DAY = TO_DATE('2014/08/12','YYYY/MM/DD')
AND T1.TYPE = 'BUY'
;

select T1.NAME
from I_TRUST t1,LEGAL T2
WHERE T1.DAY = T2.DAY
AND T1.NAME = T2.NAME
AND T1.DAY = TO_DATE('2014/08/12','YYYY/MM/DD')
AND T1.TYPE <>  T2.TYPE
;

select T1.NAME,COUNT(*)CN
from LEGAL t1
WHERE T1.DAY >= SYSDATE -30
AND T1.NAME IN (

)
GROUP BY T1.NAME
;

select T1.NAME,COUNT(*)CN
from I_TRUST t1
WHERE T1.DAY >= SYSDATE -30
AND T1.NAME IN (

)
GROUP BY T1.NAME
;
--------------------------------------------------------------------------
--2018/03/30
--〔c#〕
//list 一維陣列
public List<string> columns = new List<string>();
private List<string> _tempRows = new List<string>();

//list 二維陣列
public List<List<string>> rows = new List<List <string>>();

//get rowdata by 2 Array
foreach (System.Data.DataRow pri in GetDataTable.Rows)
{    
    _tempRows = new List<string>();

    foreach (System.Data.DataColumn col in GetDataTable.Columns)
    {
        //Console.WriteLine("{0}:{1}", col, pri[col]);
        _tempRows.Add(pri[col].ToString());
    }
    rows.Add(_tempRows);
}
--2018/04/03
 //class
namespace demo
{
    class Test
    {
    }
    class Program
    {
        static void Main(string[] args)
        {
              //Test 就是class(複數種類集合的資料型態)
              //go 就是物件(object)
              Test go = new Test(); //new 實體化
        }
    }
}
--------------------------------------------------------------------------
--2018/04/03
--〔c#〕
// class成員範例
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//宣告一個委派型別:無回傳值，無任何參數。
delegate void check();

namespace demo
{
    class Test
    {
        //宣告欄位
        public int x;
        // private field
        private DateTime Day;

        //宣告屬性
        public int Number { get; set; }
        // Public property exposes date field safely.
        public DateTime Date
        {
            get
            {
                return Day;
            }
            set
            {
                // Set some reasonable boundaries for likely birth dates.
                if (value.Year > 1900 && value.Year <= DateTime.Today.Year)
                {
                    Day = value;
                }
                else
                    throw new ArgumentOutOfRangeException();
            }

        }
        //宣告方法
        public void Add()
        {
            evtAdd();
        }
        public void CustomClass()
        {
          Number = 0;
        }
        public int Multiply(int num)
        {
            return num * Number;
        }
        //宣告事件
        //宣告一個由 DlgDoCalcDelegate 委派所支援的事件
        public event check evtAdd;
    }

    class Program
    {
        private void DoAdd()
        {
            AddMethod();
        }
        private void AddMethod()
        {
            long lngFirstValue;
            long lngSecondValue;

            long lngSum;
            Console.WriteLine("請輸入第一個進行運算數值 :");
            lngFirstValue = long.Parse(Console.ReadLine());

            Console.WriteLine("請輸入第二個進行運算數值 :");
            lngSecondValue = long.Parse(Console.ReadLine());
            lngSum = lngFirstValue + lngSecondValue;

            Console.WriteLine("{0} 與 {1} 的加總等於 {2} ", lngFirstValue, lngSecondValue, lngSum);
        }
        static void Main(string[] args)
        {
            Program go = new Program();
            Test rec = new Test();
            //將 DoAdd 方法於 evtAdd 事件中註冊
            rec.evtAdd += new check(go.DoAdd);
            Console.WriteLine("請輸Number運算數值 :");
            rec.Number = int.Parse(Console.ReadLine());
            Console.WriteLine("請輸 X 運算數值 :");
            rec.x = int.Parse(Console.ReadLine()); 
            int result = rec.Multiply(rec.x);
            Console.WriteLine("The result is {0}.",result);
            Console.WriteLine("觸發加法運算事件 …");
            
            //觸發事件。
            rec.Add();
            Console.Read();
        }
    }
}

--------------------------------------------------------------------------
--2018/04/11
--〔c#〕
//方法一
while (true)
{
    Console.WriteLine("Input number (input -1 and complete):");

    int _iPut = Convert.ToInt32(Console.ReadLine());

    if (_iPut < 0 || _iPut > 255) break;

    byte _bPut = Convert.ToByte(_iPut);

    _lInput.Add(_bPut);
}
//方法2
while (true)
{
    Console.WriteLine("Input Key  (只能輸入英文字8碼，不能含有數字):");
    string _sPut = Console.ReadLine();
    _sKey = _sPut.ToUpper();
    if (_sKey.Length == 8) break;
}
//方法3
while (_sLicense == "")
{
    Console.WriteLine("Input License key:");
    _sLicense = Console.ReadLine().Replace("-","");
}
--------------------------------------------------------------------------
--2018/04/12
--〔c#〕
// Linq orderby
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LineQ
{
    class Program
    {
        static void Main(string[] args)
        {
            // Specify the data source. 
            int[] scores = new int[] { 97, 92, 81, 60 ,20,10,100,101,155,62,88,90,80};

            // Define the query expression.
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                orderby score descending
                select score;

            // Execute the query. 
            foreach (int i in scoreQuery)
            {
                Console.Write(i + " ");
            }

            Console.ReadKey();
        }
    }
}

//Linq group by
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LineQ
{
    class Program
    {
        static void Main(string[] args)
        {
            // Specify the data source. 
            int[] scores = new int[] { 97, 92, 81, 60 ,20,10,100,101,155,62,88,90,90,100,100};

            // Define the query expression.
            var scoreQuery =
                from score in scores
                where score > 80
                orderby score descending
                group score by score into grp
                select new { name = grp.Key, cnt = grp.Count() };

            // Execute the query. 
            foreach (var i in scoreQuery)
            {
                Console.WriteLine(i.name + " "+i.cnt);
            }

            Console.ReadKey();
        }
    }
}
--------------------------------------------------------------------------
--2018/04/16
--〔c#〕
//console sample
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                string input = Console.ReadLine();
                if (args.Length == 0 && input.Length == 0)
                {
                    Console.WriteLine("please input data ");
                    Console.WriteLine("example: *.exe DATA or echo DATA | *.exe ");
                }
                else  if (args.Length != 0)
                {
                    for (int i = 0; i < args.Length ; i++)
                    {
                    	Console.WriteLine("ARGS[{0}]: {1}", i, args[i]);
                    }
                    
                }
                else if (input.Length != 0)
                {
                    Console.WriteLine("strings length: {0} Console: {1}", input.Length,input);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }

            //Console.ReadKey();
            
        }
    }
}
--------------------------------------------------------------------------
--2018/05/10
--〔c#〕
--對話方塊中openFileDialog1(WINDOWS 開啟檔案)
openFileDialog1.Filter = "Access文件|*.mdb"; //設定打開文件篩選器
openFileDialog1.Title = "選擇Access文件(限定*.mdb)";//設定打開對話框標題
openFileDialog1.Multiselect = false; //設定打開對話框中只能單擇

if (openFileDialog1.ShowDialog()==DialogResult.OK)//判斷是否選擇了文件
{
    txt_Path.Text = openFileDialog1.FileName;//文字框中顯示MDB文件名
}

--------------------------------------------------------------------------
--2018/05/23
--〔c#〕
--DataTable 基本操作
private static void DataTableRowDeleted()
{
    DataTable customerTable = new DataTable("Customers");
    // add columns
    customerTable.Columns.Add("id", typeof(int));
    customerTable.Columns.Add("name", typeof(string));
    customerTable.Columns.Add("address", typeof(string));

    // set PrimaryKey
    customerTable.Columns[ "id" ].Unique = true;
    customerTable.PrimaryKey = new DataColumn[] { customerTable.Columns["id"] };

    // add a RowDeleted event handler for the table.
    customerTable.RowDeleted += new DataRowChangeEventHandler(Row_Deleted);


    // add ten rows
    for(int id=1; id<=10; id++)
    {
        customerTable.Rows.Add(
            new object[] { id, string.Format("customer{0}", id), 
            string.Format("address{0}", id) });
    }

    customerTable.AcceptChanges();

    // Delete all the rows
    foreach(DataRow row in customerTable.Rows)
        row.Delete();
}

private static void Row_Deleted(object sender, DataRowChangeEventArgs e)
{
    Console.WriteLine("Row_Deleted Event: name={0}; action={1}", 
        e.Row["name", DataRowVersion.Original], e.Action);
}
--------------------------------------------------------------------------
--2018/08/05
--〔batchfile〕
--https://www.tutorialspoint.com/index.htm
--https://www.tutorialspoint.com/batch_script/batch_script_input_output.htm
--bathfile input 參數限定4個
@ECHO OFF

echo %1
echo %2
echo %3
echo %4

IF (%4)==() (echo "demo.cmd account password servername action" & GOTO EXIT)
IF NOT (%5)==() (echo "demo.cmd account password servername action" & GOTO EXIT)
echo "START!!!"


:EXIT
echo "EXIT!!"
 
--------------------------------------------------------------------------
 --2018/09/04
 --[c#]
             //calendar1.AutoScroll = true;
            // 找出字體大小,並算出比例
            float dpiX, dpiY;
            Graphics graphics = this.CreateGraphics();
            dpiX = graphics.DpiX;
            dpiY = graphics.DpiY;

            int intPercent = (dpiX == 96) ? 100 : (dpiX == 120) ? 125 : 150;

            float floatPercent = (dpiX == 96) ? 100 : (dpiX == 120) ? 125 : 150;

            // 針對字體變更Form的大小
            this.Height = this.Height * intPercent / 100;
            this.Width = this.Width * intPercent / 100;

            MessageBox.Show(intPercent.ToString());
            MessageBox.Show(floatPercent.ToString());

            //this.tabControl1.Size.Height = Convert.ToInt16(this.tabControl1.Size.Height * intPercent / 100);
            //this.tabControl1.Size.Width = this.tabControl1.Size.Width * intPercent / 100;
            SizeF sf = new SizeF();
            //sf = new SizeF(1.5F,1.5F);
            sf = new SizeF(floatPercent/100, floatPercent/100);

            //sf = new SizeF(dpiHight,dpiWidth);
            //tabControl1.Scale(new SizeF(1.5F, 1.5F));
            tabControl1.Scale(sf);
            //calendar1.Scale(new SizeF(0.8F, 0.8F));
            //MessageBox.Show(tabControl1.Size.Height.ToString());
            //MessageBox.Show(tabControl1.Size.Width.ToString());
            MessageBox.Show(sf.ToString());
            
--------------------------------------------------------------------------
--20180905
 --[c#]
 
         private void Form1_Load(object sender, EventArgs e)
        {
             //限定解析度
            //this.MaximumSize = new System.Drawing.Size(1920, 1200);
            //this.ClientSize = new System.Drawing.Size(1920, 1200);
            //calendar1.MaximumSize = new System.Drawing.Size(1920, 1200);
            //calendar1.ClientSize = new System.Drawing.Size(1920, 1200);
 
             ////Font
            Font f = calendar1.Font;
            float calOriginal = calendar1.Font.Size;
            float fontRatioW = calendar1.Width;
            float fontRatio = (calendar1.Width + calendar1.Height) / 2; //average change in control Height and Width
            calendar1.Font = new Font(f.FontFamily, calOriginal * 0.59F, f.Style)
             
            this.Tag = this.Height + "|" + this.Width;
            foreach (Control o in this.Controls)
            {
                o.Tag = o.Top + "|" + o.Left + "|" + o.Height + "|" + o.Width;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            foreach (Control o in this.Controls)
            {
                o.Width = (int)(double.Parse(o.Tag.ToString().Split('|')[3]) * (this.Width / double.Parse(this.Tag.ToString().Split('|')[1])));
                o.Height = (int)(double.Parse(o.Tag.ToString().Split('|')[2]) * (this.Height / double.Parse(this.Tag.ToString().Split('|')[0])));
                o.Left = (int)(double.Parse(o.Tag.ToString().Split('|')[1]) * (this.Width / double.Parse(this.Tag.ToString().Split('|')[1])));
                o.Top = (int)(double.Parse(o.Tag.ToString().Split('|')[0]) * (this.Height / double.Parse(this.Tag.ToString().Split('|')[0])));

                calendar1.Width = (int)(double.Parse(o.Tag.ToString().Split('|')[3]) * (this.Width / double.Parse(this.Tag.ToString().Split('|')[1])));
                calendar1.Height = (int)(double.Parse(o.Tag.ToString().Split('|')[2]) * (this.Height / double.Parse(this.Tag.ToString().Split('|')[0])));
                calendar1.Left = (int)(double.Parse(o.Tag.ToString().Split('|')[1]) * (this.Width / double.Parse(this.Tag.ToString().Split('|')[1])));
                calendar1.Top = (int)(double.Parse(o.Tag.ToString().Split('|')[0]) * (this.Height / double.Parse(this.Tag.ToString().Split('|')[0])));
            }
        }
--------------------------------------------------------------------------
 --2018/09/06
 --[c#]
 --解析度大小，自由變化， DPI 縮小，選日期影響calendar
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ////Monthview colors
            //monthView1.MonthTitleColor = monthView1.MonthTitleColorInactive = CalendarColorTable.FromHex("#C2DAFC");
            //monthView1.ArrowsColor = CalendarColorTable.FromHex("#77A1D3");
            //monthView1.DaySelectedBackgroundColor = CalendarColorTable.FromHex("#F4CC52");
            //monthView1.DaySelectedTextColor = monthView1.ForeColor;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 找出字體大小,並算出比例
            float dpiX, dpiY;
            Graphics graphics = this.CreateGraphics();
            dpiX = graphics.DpiX;
            dpiY = graphics.DpiY;
            //int intPercent = (dpiX == 96) ? 100 : (dpiX == 120) ? 125 : (dpiX == 144) ? 150:200;
            float floatPercent = (dpiX == 96) ? 100 : (dpiX == 120) ? 125 : (dpiX == 144) ? 150 : 200;

            float fontRatio = 70 / floatPercent; //縮小70%
            //calendar1.Font = new Font(f.FontFamily, calOriginal * 0.59F, f.Style);
            //calendar 字型縮小0.6
            calendar1.Font = new Font(calendar1.Font.FontFamily, calendar1.Font.Size * fontRatio, calendar1.Font.Style);

            this.Tag = this.Height + "|" + this.Width;
            foreach (Control o in this.Controls)
            {
                o.Tag = o.Top + "|" + o.Left + "|" + o.Height + "|" + o.Width;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            foreach (Control o in this.Controls)
            {
                o.Width = (int)(double.Parse(o.Tag.ToString().Split('|')[3]) * (this.Width / double.Parse(this.Tag.ToString().Split('|')[1])));
                o.Height = (int)(double.Parse(o.Tag.ToString().Split('|')[2]) * (this.Height / double.Parse(this.Tag.ToString().Split('|')[0])));
                o.Left = (int)(double.Parse(o.Tag.ToString().Split('|')[1]) * (this.Width / double.Parse(this.Tag.ToString().Split('|')[1])));
                o.Top = (int)(double.Parse(o.Tag.ToString().Split('|')[0]) * (this.Height / double.Parse(this.Tag.ToString().Split('|')[0])));

                calendar1.Width = (int)(double.Parse(o.Tag.ToString().Split('|')[3]) * (this.Width / double.Parse(this.Tag.ToString().Split('|')[1])));
                calendar1.Height = (int)(double.Parse(o.Tag.ToString().Split('|')[2]) * (this.Height / double.Parse(this.Tag.ToString().Split('|')[0])));
                calendar1.Left = (int)(double.Parse(o.Tag.ToString().Split('|')[1]) * (this.Width / double.Parse(this.Tag.ToString().Split('|')[1])));
                calendar1.Top = (int)(double.Parse(o.Tag.ToString().Split('|')[0]) * (this.Height / double.Parse(this.Tag.ToString().Split('|')[0])));
            }
        }

        private void monthView1_SelectionChanged_1(object sender, EventArgs e)
        {
            calendar1.SetViewRange(monthView1.SelectionStart, monthView1.SelectionEnd);
        }
    }
}


--------------------------------------------------------------------------
--20181004
--[c#]
--Excel 刪除特定行列
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.ApplicationClass;//實例化Excel對像
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//實例化Excel對像
            Microsoft.Office.Interop.Excel.Range range = null;
            Microsoft.Office.Interop.Excel.Workbook book = null;
            Microsoft.Office.Interop.Excel.Worksheet sheet =null;

            Console.WriteLine("*****Start*****");
            string input = @"D:\demo\20181004\demo\TEST.xls";

            try
            {
                Console.WriteLine("path: {0}",input);
                //Console.ReadKey();


                object missing = Missing.Value;//取得缺少的object類型值
                //打開指定的Excel文件
                //Microsoft.Office.Interop.Excel.Workbook workbook = excel.Application.Workbooks.Open(input, missing, missing, missing);
                //((Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["RAW"]).Delete();//刪除選擇的工作表
                //Console.WriteLine("工作表刪除成功！");

                excel.Visible = false;
                //打開指定的Excel文件
                book = excel.Workbooks.Open(input, Missing.Value, false, Missing.Value, Missing.Value, Missing.Value, true, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                //int wsCount = book.Worksheets.Count;//取得excel file sheet counts
                //for (int i = 1; i <= wsCount; i++)
                //{
                //    sheet = (Microsoft.Office.Interop.Excel.Worksheet)book.Worksheets[i];
                //    //获取编辑范围
                //    range = (Microsoft.Office.Interop.Excel.Range)sheet.Rows[1, Missing.Value];
                //    //删除整行
                //    range.Delete(Microsoft.Office.Interop.Excel.XlDirection.xlDown);

                //    //更新单元格内容
                //    sheet.Cells[1, 3] = "pcID";

                //    //保存编辑
                //    book.Save();
                //}




                sheet = (Microsoft.Office.Interop.Excel.Worksheet)book.Worksheets[1];//開啟第一個sheet
                //获取编辑范围
                range = (Microsoft.Office.Interop.Excel.Range)sheet.Rows[3, Missing.Value];//準備刪除第三行
                //删除整行
                range.Delete(Microsoft.Office.Interop.Excel.XlDirection.xlDown);
                //保存编辑
                book.Save();
                //close book
                book.Close(Missing.Value, Missing.Value, Missing.Value);
                //退出excel application，可以將前面的excel.Visible = false改为excel.Visible = true看看;
                excel.Workbooks.Close();
                excel.Quit();
                excel.Visible = true;











                excel.Application.DisplayAlerts = false;//不顯示提示對話框
                //workbook.Save();//儲存工作表
                System.Diagnostics.Process[] excelProcess = System.Diagnostics.Process.GetProcessesByName("EXCEL");//實例化進程對像
                foreach (System.Diagnostics.Process p in excelProcess)
                 p.Kill();//關閉進程
                Console.WriteLine("***** END *****");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                excel.Application.DisplayAlerts = false;//不顯示提示對話框
                //workbook.Save();//儲存工作表
                System.Diagnostics.Process[] excelProcess = System.Diagnostics.Process.GetProcessesByName("EXCEL");//實例化進程對像
                foreach (System.Diagnostics.Process p in excelProcess)
                p.Kill();//關閉進程
                Console.ReadKey();
            }

        }
    }
}

--------------------------------------------------------------------------
 --2018/10/05
 --[Excel]
 let
    來源 = Folder.Files("C:\Users\maple\Desktop\power BI\Power BI(二)案例操作\02-Power Query(二)\04-四縣市人口合併Excel"),
    已移除其他資料行 = Table.SelectColumns(來源,{"Content"}),
    已新增自訂 = Table.AddColumn(已移除其他資料行, "取得表格資料", each Excel.Workbook([Content])),
    已移除資料行 = Table.RemoveColumns(已新增自訂,{"Content"}),
    #"已展開 取得表格資料" = Table.ExpandTableColumn(已移除資料行, "取得表格資料", {"Name", "Data", "Item", "Kind", "Hidden"}, {"取得表格資料.Name", "取得表格資料.Data", "取得表格資料.Item", "取得表格資料.Kind", "取得表格資料.Hidden"}),
    已新增自訂1 = Table.AddColumn(#"已展開 取得表格資料", "去除標頭", each Table.PromoteHeaders([取得表格資料.Data])),
    已移除其他資料行1 = Table.SelectColumns(已新增自訂1,{"去除標頭"}),
    #"已展開 去除標頭" = Table.ExpandTableColumn(已移除其他資料行1, "去除標頭", {"日期", "縣市", "區  域  別", "戶數", "男", "女", "合計"}, {"日期", "縣市", "區  域  別", "戶數", "男", "女", "合計"})
in
    #"已展開 去除標頭"
--------------------------------------------------------------------------
--2018/10/13
--[c#]
--http://www.eion.com.tw/Blogger/?Pid=1150
--http://limitedcode.blogspot.com/2014/11/c-datetime.html
--https://dotblogs.com.tw/rainmaker/archive/2013/09/02/116105.aspx

//程式語法C#C# DateTime 日期轉換格式, 時間計算, 日期天數計算
//C# Date() 日期與時間
//標準日期和時間格式字串使用單一格式規範，定義日期和時間值的文字表示。

//任何包含一個以上字元(包含空白字元)的日期和時間格式字串都會解譯為自訂日期和時間格式字串，
//自訂日期和時間格式字串可以搭配日期和時間執行個體的 ToString 方法或是支援複合格式的方法使用。


//轉換日期格式為字串
//文法：(參數大小寫解譯不同 MM=month, mm=Minutes, HH=24hours, hh=12hours)
DateTime myDate = DateTime.Now;
string myDateString = myDate.ToString("yyyy-MM-dd HH:mm:ss");
//2011-10-16 02:33:54


//轉換字串格式為日期
DateTime dt = Convert.ToDateTime(myDateString);
//2011/10/16 上午 02:33:54

//計算兩個時間差
DateTime sDate = Convert.ToDateTime("2010-10-15 15:50:39");
DateTime eDate = Convert.ToDateTime("2010-10-25 15:50:39");
TimeSpan ts = sDate - eDate;
double days = ts.TotalDays;
TextBox.Text = "差距 " + Convert.ToInt32(days).ToString() + "天";
//差距 -10 天

//[Application Example]
DateTime dt = DateTime.Now; 取得目前日期時間

//本週一的日期
DateTime startWeek = dt.AddDays(1-Convert.ToInt32(dt.DayOfWeek.ToString("d")));
//本週日的日期
DateTime endWeek = startWeek.AddDays(6);
//本月之月初的日期
DateTime startMonth = dt.AddDays(1 - dt.Day);
//本月之月底的日期
DateTime endMonth = startMonth.AddMonths(1).AddDays(-1);
//本季初的日期
DateTime startQuarter = dt.AddMonths(0-(dt.Month-1) % 3).AddDays(1-dt.Day);
//本季末的日期
DateTime endQuarter = startQuarter.AddMonths(3).AddDays(-1);
//本年年初的日期
DateTime startYear = new DateTime(dt.Year, 1, 1);
//本年年末的日期
DateTime endYear = new DateTime(dt.Year, 12, 31);

//上年度的起止日期
startBeforeYear = DateTime.Parse(DateTime.Now.ToString("yyyy-01-01")).AddYears(-1).ToShortDateString();
endBeforeYear = DateTime.Parse(DateTime.Now.ToString("yyyy-12-31")).AddDays(-1).ToShortDateString();

//本年度的起止日期
dateTimePickerStart.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-01-01"));
dateTimePickerEnd.Value = DateTime.Now;

//下年度的起止日期
startNextYear = DateTime.Parse(DateTime.Now.ToString("yyyy-01-01")).AddYears(1).ToShortDateString();
endNextYear = DateTime.Parse(DateTime.Now.ToString("yyyy-12-31")).AddYears(2).AddDays(-1).ToShortDateString();
dateTimePickerStart.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-01-01")).AddYears(-1);
dateTimePickerEnd.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-12-31")).AddYears(-1);

//C#計算兩個時間年份月份差
DateTime dt1 = Convert.ToDateTime("2008-8-8");
DateTime dt2 = System.DateTime.Now;
int Year = dt2.Year - dt1.Year;
int Month = (dt2.Year - dt1.Year) * 12 + (dt2.Month - dt1.Month);
--------------------------------------------------------------------------
 --20181228
 --Looping a switch statement

             int menuchoice  = 0;
            while (menuchoice != 7)
            {

                Console.WriteLine("MENU");
                Console.WriteLine("Please enter the number that you want to do:");
                Console.WriteLine("1. Do thing A");
                Console.WriteLine("2. Do thing B");
                Console.WriteLine("3. Do thing C");
                Console.WriteLine("4. Do thing D");
                Console.WriteLine("5. Do thing E");
                Console.WriteLine("6. Do thing F");
                Console.WriteLine("7. Exit");

                menuchoice = int.Parse(Console.ReadLine());

                switch (menuchoice)
                {
                    case 1:
                        Console.WriteLine("Thing A has been done");
                        break;
                    case 2:
                        Console.WriteLine("Thing B has been done");
                        break;
                    case 3:
                        Console.WriteLine("Thing C has been done");
                        break;
                    case 4:
                        Console.WriteLine("Thing D has been done");
                        break;
                    case 5:
                        Console.WriteLine("Thing E has been done");
                        break;
                    case 6:
                        Console.WriteLine("Thing F has been done");
                        break;
                    case 7:
                        break;  //edit
                    default:
                        Console.WriteLine("Sorry, invalid selection");
                        break;
                }
            }
-------------------------------------------------------------------------- 
             #region 避免重覆process
            //避免重覆process
            bool createNew;
            System.Threading.Mutex appMutex = new System.Threading.Mutex(true, APP_NAME, out createNew);
            if (!createNew)
            {
                appMutex.Close();
                System.Environment.Exit(System.Environment.ExitCode);
            }
            #endregion 避免重覆process
--------------------------------------------------------------------------
set filepath="C:\some path\having spaces.txt"

for /F "delims=" %%i in (%filepath%) do set dirname="%%~dpi" 
for /F "delims=" %%i in (%filepath%) do set filename="%%~nxi"
for /F "delims=" %%i in (%filepath%) do set basename="%%~ni"

echo %dirname%
echo %filename%
echo %basename%
 
or 
FOR /R %LoadFile% %%i in (*.xlsx) DO (ECHO %%i)
FOR /R %LoadFile% %%i in (*.xlsx) DO (ECHO %%~nxi.txt)
--------------------------------------------------------------------------
 
