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
 [Windows bath file(cmd) IF 指令 ]
::https://peterju.gitbooks.io/cmddoc/content/loop.html

條件判斷
IF [NOT] EXIST filename command
IF [NOT] EXIST filename (command) ELSE (command)
IF [/I] [NOT] item1==item2 command
IF item1 Compare-op item2 command
IF item1 Compare-op item2 (command) ELSE (command)
IF DEFINED variable command

Compare-op：
1
EQU – 等於
2
NEQ – 不等於
3
LSS – 小於
4
LEQ – 小於或等於
5
GTR – 大於
6
GEQ – 大於或等於

大小相同
1
if "ABC"=="ABC" echo 大小寫相同

區分大小寫 
1
if not "ABC"=="abc" echo 大小寫不同

不區分大小寫
1
if /I "ABC"=="abc" echo 兩者相同相等

判斷檔案是否存在
1
if NOT EXIST C:\text.txt echo c:\text.txt檔案不存在

如果環境變數是空，可在變數外加上特殊符號，以防止錯誤發生
1
IF "2" == "15" echo "bigger"

確認環境變數是否存在
view sourceprint?
1
IF DEFINED a echo 123
2
set a=5
3
IF DEFINED a echo 123
4
set a=
5
IF DEFINED a echo 123


[Windows bath file(cmd) For 使用 ]

使用Batch中的For指令

::遞迴搜尋指定的路徑下所有符合檔案的 for /R 迴圈
FOR /R – 列舉目前目錄下的全部子目錄名所有檔案
FOR /R [[drive:]path] %variable IN (set) DO command [command-parameters]
1
FOR /R %i IN (*) DO echo %i
exp:
::將 c:\temp\ 目錄與所有子目錄下的 *.bak 刪除
for /R c:\temp\ %%G in (*.bak) do del "%%G"

::找出符合條件之目錄的 for /D 迴圈
FOR /D – 列舉目前目錄下的子目錄名
FOR /D %variable IN (set) DO command [command-parameters]
1
FOR /D %i IN (*) DO echo %i

exp:
::顯示使用者目錄中的所有目錄名稱 此例必須直接在命令列輸入(注意變數名稱的差別)、環境變數 userprofile 代表使用者目錄
for /D %i in (%userprofile%\*) DO @echo %i

::可以設定開始數值、增/減數值、停止數值的 for /L 迴圈
FOR /L – 以增量形式從開始到結束一個數字序列
FOR /L %variable IN (start,step,end) DO command [command-parameters]
1
set sum=0
2
FOR /L %i IN (1, 1, 100) DO set /a sum=sum+%i
3
echo %sum%
4
>> 5050

::逐行讀取文字檔的 for /F 迴圈
FOR /F – 做在一個檔案裡的指令
FOR /F ["options"] %variable in (file-set) do command [command-parameters]
FOR /F ["options"] %variable in ("string") do command [command-parameters]
FOR /F ["options"] %variable in ('command') do command [command-parameters]
file-set為一個或多個檔案名稱。/f 分析每個檔案的每一行，跳過空白行。"options" 關鍵字：
eol=c 用來決定斷行符號，預設為 \n，但可換成其他字元（其中 c 只能是一個字元）
skip=n 用來決定要先跳過幾層迴圈（也就是跳過前面幾行的意思）
delims=xxx 用來決定欄位的分隔字元，預設為空白與TAB符號，並可自訂多個字元，多個字元時需用逗號(,)區隔開。
tokens=x,y,m-n用來決定一次要取出幾個欄位，第一個欄位會存放在第一個自動變數，第二個欄位會存放在第二個自動變數裡，依此類推，說明如下。
第一個變數為%i並設並tokens=1-3，則後面將得到的變數為%%i、%%j、%%k
1
Set a=aaa_bbb_111-222-333
2
For /F "tokens=1-3 delims=_" %%i in ("%a%") do echo %%i  %%j  %%k
3
>> aaa  bbb  111-222-333
第一個變數為%i並設並tokens=2,3，則後面將得到的變數為%%i、%%j
1
Set a=aaa_bbb_111-222-333
2
For /F "tokens=1-3 delims=_" %%i in ("%a%") do echo %%i  %%j
3
>> bbb  111-222-333

[Windows bath file(cmd) 變數使用]

環境變數的使用，可以做到跟VC++中CString的用法類似，各位可以參考如下。 
01
set A=1234567890
02
set B=%A%
03
 
04
REM 從第3 字元後開始取2個字元
05
set B=%A:~3,2%
06
echo %B%
07
>>45
08
 
09
REM 從前面開始取5個字元
10
set B=%A:~,5%
11
echo %B%
12
>>12345
13
 
14
REM 從第3字元後開始取到後面。
15
set B=%A:~3%
16
echo %B%
17
>>4567890
18
 
19
REM 從後面開始取前5個字元。
20
set B=%A:~-5%
21
echo %B%
22
>>67890
23
 
24
REM 從開頭取到最後2個字元不取。
25
set B=%A:~0,-2%
26
echo %B%
27
>>12345678
28
 
29
REM 字元中有5的取代成sss。
30
set B=%A:5=sss%
31
echo %B%
32
>>1234sss67890
其他常用系統變數
系統變數
描述
%n(%0、%1 ~ %9)
外部變數輸入所使用的變數代稱，如C/C++的Argv
%CMDEXTVERSION%
展開為目前的命令處理擴充功能的版本號碼
%CMDCMDLINE%
處理目前命令提示字元視窗命令的cmd.exe的完整路徑
%CD%
目前的工作資料夾
%DATE%
set now=%date:~0,4%%date:~5,2%%date:~8,2%
目前的系統日期
%ERRORLEVEL%
最近執行過的命令的錯誤碼；非零的值表示發生過的錯誤碼
%ProgramFiles%
應用程式目錄，預設是C:\Program Files
%ProgramFiles(x86)%
應用程式目錄，預設是C:\Program Files(x86)
%Path%
執行檔的搜尋路徑
%RANDOM%
顯示0到32767之間的十進位整數亂數
%SystemRoot%
系統根目錄，預設是C:\WINNT或C:\WINDOWS
%SystemDirectory%
系統目錄，預設是C:\WINNT\System32或C:\WINDOWS\System32
%TIME%
目前的系統時間
%Temp%、%Tmp%
暫存檔目錄
%USERNAME%
使用者帳號名稱
%WINDIR%
Windows目錄，預設是C:\WINNT或C:\WINDOWS

好像有點誤解，補充說明一下 囧

    %~dp0    批次檔所在路徑，例如
             C:\Program Files\Mozilla Firefox\
             或 UNC 路徑，例如
             \\Server\Share\Program Files\Mozilla Firefox\

    %~d0     批次檔所在磁碟代號，例如
             C:
             或 UNC 路徑的雙反斜線
             \\

    %~p0     批次檔所在路徑，不含磁碟代號，例如
             \Program Files\Mozilla Firefox\
             或開頭不帶雙反斜線的 UNC 路徑，例如
             Server\Share\Program Files\Mozilla Firefox\

    %cd%     目前工作路徑，非根路徑時後面不帶反斜線，例如
             C:\Program Files\Mozilla Firefox

寫個批次檔測試一下比較容易瞭解 %~dp0 與 %cd% 的差別

    @ECHO OFF
    ECHO %%~dp0 = %~dp0
    ECHO %%cd%%  = %cd%
    PAUSE

當批次檔與目前工作路徑都在 C:\Program Files\Mozilla Firefox\ 時，執行
批次檔結果如下

    %~dp0 = C:\Program Files\Mozilla Firefox\
    %cd%  = C:\Program Files\Mozilla Firefox
    請按任意鍵繼續 . . .

若批次檔所在路徑不變，目前工作路徑在 U:\USB\ 時，執行批次檔結果如下

    %~dp0 = C:\Program Files\Mozilla Firefox\
    %cd%  = U:\USB
    請按任意鍵繼續 . . .





若在批次檔中使用 SET 命令將 cd 指定為環境變數，則 %cd% 會被取代，不過
這不表示目前工作路徑被改變，所以 SET CD="%~dp0" 這樣寫應該會有問題說

假設批次檔與執行檔放在一起，以下有三種方法提供參考

1. 如同原文裡的範例，修改 PATH 環境變數

    SET PATH=%~dp0
    start Program.exe

2. 切換目前工作路徑

    %~d0
    cd %~dp0
    start Program.exe

3. 以完整路徑方式執行

    start "" "%~dp0Program.exe"

(sample)
@echo off
::ftp action file
echo user jeff> ftpcmd.dat
echo 123456>> ftpcmd.dat
echo bin>> ftpcmd.dat
echo prompt>> ftpcmd.dat
echo mput %1>> ftpcmd.dat
echo quit>> ftpcmd.dat
sleep 1

::ftp  file to server
ftp -n -s:ftpcmd.dat 172.20.58.42 >ftp.log

sleep 1

for /F %%i in ('type ftp.log ^|grep  "Successfully transferred" ^|wc -l') DO set checklog=%%i

::echo %checklog%

if '%checklog%' GTR '0' ( echo FTP Successfully transferred & goto exit ) else ( echo FTP transferred fail & echo please double check )

rem del ftpcmd.dat

:exit
//-----------------------------------------------------
批處理程式(.Bat)相關知識：
1. 假設父批處理程序接收兩個可替換參數，並希望將它們傳給Sub.bat。可在父批理程序中使用命令：call Sub.bat%1%2
2. 設置變量，並等待使用者輸入：set /p Name = 請輸入使用者名稱（註：/p 讓執行暫停，並提供使用者輸入的機會）
3. 取得變量值：%變量名稱%
4. 輸出變量值：如：echo 您輸入的使用者名稱為：%Name%
5. 執行時不顯示指令程式碼：@echo off
6. 暫停：pause
7. 註解：::
8. 批參數(%n)的替代已被增強。可以使用以下語法：
        %~1        - 刪除引號(")，擴充 %1
        %~f1        - 將 %1 擴充到一個完全合格的路徑名
        %~d1        - 僅將 %1 擴充到一個驅動器號
        %~p1        - 僅將 %1 擴充到一個路徑
        %~n1        - 僅將 %1 擴充到一個文件名
        %~x1        - 僅將 %1 擴充到一個文件擴展名
        %~s1        - 擴充的路徑指含有短名
        %~a1        - 將 %1 擴充到文件屬性
        %~t1        - 將 %1 擴充到文件的日期/時間
        %~z1        - 將 %1 擴充到文件的大小
        %~$PATH : 1 - 查找列在 PATH 環境變量的目錄，並將 %1
                      擴充到找到的第一個完全合格的名稱。如果環境
                      變量名未被定義，或者沒有找到文件，此組合鍵會
                      擴充到空字符串

       可以組合修定符來取得多重結果：
        %~dp1      - 只將 %1 擴展到驅動器號和路徑
        %~nx1      - 只將 %1 擴展到文件名和擴展名
        %~dp$PATH:1 - 在列在 PATH 環境變量中的目錄裡查找 %1，
                      並擴展到找到的第一個文件的驅動器號和路徑。
        %~ftza1    - 將 %1 擴展到類似 DIR 的輸出行。
//-----------------------------------------------------
[batchfile 環境變數]
::暫時方法
@echo off
Title JAVA_PATH By Charlotte.HonG& Color 1A

set str=%PATH%;%~dp0jdk1.8.0_101\bin;
set PATH = "%str%"

exit

::永久方法
@echo off
Title JAVA_PATH By Charlotte.HonG& Color 1A

set str=%PATH%;%~dp0jdk1.8.0_101\bin;
setx /m PATH "%str%"

exit

[batchfile sample]
--限定input 1個變數
@echo off

::exp: kill_proc.cmd  process_name
IF (%1)==() (echo "kill_proc.cmd process_name" & GOTO EXIT)
IF NOT (%2)==() (echo "kill_proc.cmd process_name" & GOTO EXIT)

ECHO "START !!!!"

ECHO "PROC~"

:EXIT
ECHO "END !!!!"
--限定input 2個變數
@echo off

::exp: kill_proc.cmd  process_name
IF (%1)==() (echo "kill_proc.cmd process_name" & GOTO EXIT)
IF (%2)==() (echo "kill_proc.cmd process_name" & GOTO EXIT)
IF NOT (%3)==() (echo "kill_proc.cmd process_name" & GOTO EXIT)

ECHO "START !!!!"

ECHO "PROC~"

:EXIT
ECHO "END !!!!"

--限定input 3個變數
@echo off

::exp: kill_proc.cmd  process_name
IF (%1)==() (echo "kill_proc.cmd process_name" & GOTO EXIT)
IF (%3)==() (echo "kill_proc.cmd process_name" & GOTO EXIT)
IF NOT (%4)==() (echo "kill_proc.cmd process_name" & GOTO EXIT)

ECHO "START !!!!"

ECHO "PROC~"

:EXIT
ECHO "END !!!!"
//-----------------------------------------------------
[batchfile sample]
::強制顯示為 6 為 06(兩位數)
::Digital complement two digit length
set %2=6
set s=
set a=
set /a a=%2+100
set s=!s! !a:~1!
echo "OUT: "%s%
//-----------------------------------------------------
[ftp windows  指令]
exp:
ftp -n -s:ftpcmd.dat 172.20.58.42 >ftp.log

相關參數（來自 Windows 內建說明檔）：
-v
抑制顯示遠端伺服器的回應。
-n
抑制在初始連線時自動登入。
-i
關閉多檔案傳送期間的互動提示。
-d
啟用偵錯，以顯示用戶端與伺服器之間所傳遞的所有 ftp 指令。
-g
啟用檔案名稱通用慣例，以在本機檔案及路徑名稱中使用萬用字元 (* 與 ?) (請參閱線上 [指令參照] 中的 glob 指令)。
-s:filename
指定內含 ftp 指令的文字檔；此指令會在 ftp 啟動之後自動執行。此參數不可含有空格。請改以此參數取代重新導向 (>)。
-a
於連結資料連線時使用本機的介面。
-w:windowsize
覆寫預設的轉送緩衝區大小 4096。
computer
指定電腦名稱或要連線之遠端電腦的 IP 位址。指定此參數時，請務必將其置於行中的最後一個參數。


//-----------------------------------------------------
-------------------------------------------------------------------------
::[batchfile]
■DEL：刪除檔案指令，而後面附加的參數各代表意義如下：
/F：強制刪除唯讀檔案
/A：刪除有附加屬性的檔案
/Q：刪除時不需確認
EXP:
DEL /F /A /Q \\?\%1

■RD：刪除資料夾指令，後面附加的參數各代表如下：
/S：如果資料夾內有檔案一併刪除
/Q：刪除時不需確認
EXP:
RD /S /Q \\?\%1

::字串的取代
(140.128.71.1) --> [140.128.71.1]
::範例 
@echo off
set var=(140.128.71.1)
set result=%var:(=[%
set result=%result:)=]%
echo %result%
Pause

::說明
字串取代符號說明
冒號(:)
字串中想要被替換的子字串
等號(=)
替換後的子字串

//--------------------------------------------------------------
[batchfile]
::取得日期格式yyyymmdd(20181218)
For /f "tokens=1-3 delims=/ " %%a in ('date /t') do (set datetime=%%a%%b%%c)

::splist(FS 用法 -F)
echo H1RN-001 |gawk  -F "-" "{print $1}"
H1RN

批處理中START和CALL命令的區別
用法：

1、START 命令

批處理中調用外部程序的命令（該外部程序在新窗口中運行，批處理程序繼續往下執行，不理會外部程序的運行狀況），如果直接運行外部程序則必須等外部程序完成後才繼續執行剩下的指令

　　例：start explorer d:\\

　　調用圖形界面打開D盤

2、CALL 命令

　　CALL命令可以在批處理執行過程中調用另一個批處理，當另一個批處理執行完後，再繼續執行原來的批處理

　　CALL command

　　調用一條批處理命令，和直接執行命令效果一樣，特殊情況下很有用，比如變量的多級嵌套，見教程後面。在批處理編程中，可以根據一定條件生成命令字符串，用call可以執行該字符串，見例子。

　　CALL [drive:][path]filename [batch-parameters]

　　調用的其它批處理程序。 filename 參數必須具有 .bat 或 .cmd 擴展名。

　　CALL :label arguments

　　調用本文件內命令段，相當於子程序。被調用的命令段以標籤:label開頭

　　以命令goto :eof結尾。

　　另外，批腳本文本參數參照(%0、%1、等等)已如下改變:

　　批腳本里的 %* 指出所有的參數(如 %1 %2 %3 %4 %5 ...)

　　批參數(%n)的替代已被增強。您可以使用以下語法:（看不明白的直接運行後面的例子）

　　%~1 - 刪除引號(\")，擴充 %1

　　%~f1- 將 %1 擴充到一個完全合格的路徑名

　　%~d1- 僅將 %1 擴充到一個驅動器號

　　%~p1- 僅將 %1 擴充到一個路徑

　　%~n1- 僅將 %1 擴充到一個文件名

　　%~x1- 僅將 %1 擴充到一個文件擴展名

　　%~s1- 擴充的路徑指含有短名

　　%~a1- 將 %1 擴充到文件屬性

　　%~t1- 將 %1 擴充到文件的日期/時間

　　%~z1- 將 %1 擴充到文件的大小

　　%~$PATH : 1 - 查找列在 PATH 環境變量的目錄，並將 %1

　　擴充到找到的第一個完全合格的名稱。如果環境

　　變量名未被定義，或者沒有找到文件，此組合鍵會

　　擴充到空字符串

　　可以組合修定符來取得多重結果:

　　%~dp1 - 只將 %1 擴展到驅動器號和路徑

　　%~nx1 - 只將 %1 擴展到文件名和擴展名

　　%~dp$PATH:1 - 在列在 PATH 環境變量中的目錄裡查找 %1，

　　並擴展到找到的第一個文件的驅動器號和路徑。

　　%~ftza1 - 將 %1 擴展到類似 DIR 的輸出行。

　　在上面的例子中，%1 和 PATH 可以被其他有效數值替換。

　　%~ 語法被一個有效參數號碼終止。 %~ 修定符不能跟 %*使用

　　注意：參數擴充時不理會參數所代表的文件是否真實存在，均以當前目錄進行擴展

　　要理解上面的知識，下面的例子很關鍵。

　　例：

　　@echo off

　　Echo 產生一個臨時文件 > tmp.txt

　　Rem 下行先保存當前目錄，再將c:\\windows設為當前目錄

　　pushd c:\\windows

　　Call :sub tmp.txt

　　Rem 下行恢復前次的當前目錄

　　Popd

　　Call :sub tmp.txt

　　pause

　　Del tmp.txt

　　exit

　　:sub

　　Echo 刪除引號： %~1

　　Echo 擴充到路徑： %~f1

　　Echo 擴充到一個驅動器號： %~d1

　　Echo 擴充到一個路徑： %~p1

　　Echo 擴充到一個文件名： %~n1

　　Echo 擴充到一個文件擴展名： %~x1

　　Echo 擴充的路徑指含有短名： %~s1

　　Echo 擴充到文件屬性： %~a1

　　Echo 擴充到文件的日期/時間： %~t1

　　Echo 擴充到文件的大小： %~z1

　　Echo 擴展到驅動器號和路徑：%~dp1

　　Echo 擴展到文件名和擴展名：%~nx1

　　Echo 擴展到類似 DIR 的輸出行：%~ftza1

　　Echo.

　　Goto :eof

　　例：

　　set aa=123456

　　set cmdstr=echo %

　　call %cmdstr%

　　pause

　　本例中如果不用call，而直接運行%cmdstr%，將顯示結果 %，而不是123456

補充：
補充裡說的錯誤地方是對的,凡是複合句,(有括號括起來的或有&& ||連接起來的)批處理中對於一對%%中的變量總是一次性取其在整個複合句之前值的, 
所以此處在兩處call的過程之前就已經解釋成沒賦值,即為空值, 而echo 後為空的命令是顯示當前回顯狀況的
解決方法,一種方法是之前(也就是第二行處)加setlocal enabledelayedexpansion然後此處的%用!替換, 第二種是此句改成call echo %%hex%%%%binsymbol%%
第三種是也許可以在復合句外去執行,此例可把此句移到倒數第二行也行
另外如果單就此代碼的結果那就不如改"算法",直接從0x00列到0xF

exp:
@echo off
Code Snippet
setlocal enabledelayedexpansion

set a=
set s=

FOR /L %%i in (1,1,%1) DO ( 
set /a a=%%i+100
echo !a!
set s=!s! !a:~1!
)

echo out: %s%

::批次指令：特殊字元
批次指令：特殊字元
‧ 括號：( ..... )
‧ pipe : |
‧ 導向: > >> <
‧ 特殊字元避開：
o & ()[]{}^=;!'+,`~ 加""表示為純字元，失去特殊意義
o &<>()@^| 加^表示為自身字元，失去特殊意義
‧ 注意：batch檔中把%視為特殊字元
o 要使用%的字元者，要寫成%%才行
o 指令列中的 %i ，在Batch中要寫成%%i
o 指令列中的3%2，在 Batch中要寫成3%%2
批次指令： For
‧ 重覆性處理
o for %i in (monkey dog monkey) do @echo I love %i
‧ 顯示目錄中的特定檔案
o for %j in (%windir%\*.txt) do type %j
‧ 從1顯示到100
o for /L %i in (1,1,100) do echo %i
‧ 列出目前所有的目錄
o for /D %i in (*) do echo %i

For /f 的使用!!!
‧ 將指定文檔逐行顯示
o for /f %i in (%windir%\system32\eula.txt) do @echo %i
‧ 剖析文字檔，抓出第2、3個區塊
o for /f “delims=, tokens=3,7" %i in (%windir%\svcpack.log) do @echo %i %j
‧ 剖析字串
o for /f "tokens=1,2,3,4" %i in ("my name is jtchen") do @echo your %j is %l, welcome!!
‧ 將執行結果視為文檔，進行剖析
o for /F %i in ('dir/b/ad') do echo %i
o 如果不要剖析呢?? (即希望整行輸出)
‧ 剖析輸出：秀出目前的環境變數
o for /f "delims== tokens=1" %a in ('set') do @echo %a
//------------------------------------------------------------
[batch file]
--exception handling
@ECHO OFF
PING 10.0.0.123
IF ERRORLEVEL 1 GOTO NOT-THERE
ECHO IP ADDRESS EXISTS
PAUSE
EXIT
:NOT-THERE
ECHO IP ADDRESS NOT NOT EXIST
PAUSE
EXIT
-------------------------------------------------------------------------
MTK_B2B_LAB只轉檔案字首開頭是數字的
MTK_B2B_STD只轉檔案字首開頭是英文的

@ECHO OFF
setlocal enabledelayedexpansion
cls

set LoadFile=D:\Temp\XML\send\
set Local=%~d0
set Folder=%~dp0

%Local%
cd %Folder%

FOR /R %LoadFile% %%i in (*.xlsx) DO (
set file=%%~nxi
set exe=%%i
set check=!file:~,1!
set lab=
set std=
ECHO !file!

FOR /F %%a in ('ECHO !check! ^|gawk "{ if( $0 ~ /[0-9]/){print 10} }"') DO (set lab=%%a)
IF !lab! EQU 10 (ECHO "TB_MTK_B2B_LAB.awk Process is already!!")
FOR /F %%a in ('ECHO !check! ^|gawk "{ if( $0 ~ /[a-zA-Z]/){print 100} }"') DO (set std=%%a)
IF !std! EQU 100 (ECHO "TB_MTK_B2B_STD.awk Process is already!!")

ECHO -------------------------------------------------------
)

-------------------------------------------------------------------------
::20190222
[ELK]
::C:\Program Files\java-1.8.0-openjdk-1.8.0.201\jre\lib\i386\jvm.cfg
#-server KNOWN
#-client ALIASED_TO -server
-server KNOWN
-client IF_SERVER_CLASS -server
-minimal KNOWN

::C:\elasticsearch-5.6.15\config\jvm.options
-Xms500m
-Xmx500m

::C:\elasticsearch-5.6.15\config\elasticsearch.yml
cluster.name: rychenga
node.name: node-1
node.attr.rack: r1
path.data: D:\DATA
path.logs: D:\DATA\logs
network.host: 172.20.56.33
http.port: 9200
discovery.zen.ping.unicast.hosts: ["172.20.56.33"]
discovery.zen.minimum_master_nodes: 1
#xpack.ml.enabled: false



-------------------------------------------------------------------------
::20190225
::ELASTICSEARCH STARTUP
C:\elasticsearch-5.6.15\bin\elasticsearch.bat

::檢查 Service info
http://172.20.56.33:9200/

::Admin tool(cerebro)
C:\cerebro-0.8.1\bin\cerebro.bat
http://localhost:9000/#/overview?host=http:%2F%2F172.20.56.33:9200

::FileBeat
D:\jeff.cheng\tool\filebeat\
D:\jeff.cheng\tool\filebeat\filebeat.exe -c filebeat.full.yml


::kibana
C:\kibana-5.6.15\bin\kibana.bat
http://172.20.56.33:5601/

::NEST
https://www.nuget.org/packages/NEST/6.5.0
https://github.com/elastic/elasticsearch-net
https://dotblogs.com.tw/supershowwei/2015/12/24/171106
https://www.itread01.com/content/1501141214.html
http://www.cnblogs.com/ljhdo/p/5160329.html

安裝後引用了以下三個DLL
Elasticsearch.Net.dll（2.4.4）
Nest.dll（2.4.4）
Newtonsoft.Json.dll（9.0版本）
"visual studio 2005" NuGet Packages

::Net. 
https://docs.microsoft.com/zh-tw/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
https://stackoverflow.com/questions/7929013/making-a-curl-call-in-c-sharp
::Json Nest.dll（2.4.4）
Newtonsoft.Json.dll
https://ithelp.ithome.com.tw/articles/10195057
::winform CURL
https://blog.csdn.net/yupu56/article/details/53106830

::CURL
https://xyz.cinc.biz/2012/10/windowscmdhtml.html
https://stackoverflow.com/questions/8829468/elasticsearch-query-to-return-all-records
::When we do a GET:
http://localhost:9200/[your index name]/_search?size=[no of records you want]&q=*:*
::When we do a POST:
http://localhost:9200/[your_index_name]/_search
{
  "size": [your value] //default 10
  "from": [your start index] //default 0
  "query":
   {
    "match_all": {}
   }
}  

::example
http://172.20.56.33:9200/filebeat*/_search?pretty=true&q=%2258%2037%2018%2000005899%2079526D5F02CBCC9964656685BD8EC193E096B3E573CBFEA36A28CB42E440B282D80AF5F0752806976F53B023F4282E34DCF3D916B50A7A280F486D1B58B7E2EB1386D07F7D1B5925573A8F9C2D43AD60CB940216A4AE721E08C4C001FDCF898504B79D606947AA01812B362B823022BA9029B8078218481432A207F76F8B232A44D5B769DDFE73FAC4AAF4A8AD4C927D4BC4018BD2F19C2803F99BF9C3E5E69D541D474D6F46283E160C5DCD4247C9E31D7B2507CE692EC69A56733FE95387ED6DCEDB68E34D81DD6537AD440A872AD837AC674FC98191944B6D307C9B82DC63B8FECF4DE5404047F598EBA03C9B5A0746A76AB2C2070265837419CC2DE2A3827D1182F5B5673BC318AD2C7CE0F3012CFBFDED430E795B09A8558CD4C573A29DEA00000145000018000058998CD40000%204D%2000005898%20C79AA9D503C0437ED83D7518AB7F1666826585637E5EC9EA2AAC24CC64F5E2263516BDE66119721F0CB46B3E0FBCD0403731E804257063AD3816A9DF4DB20C2E1D826B9E28CD8570B876881BBF007ED818E32E78FB4B15D437C4F135394E127B21EAFDD320412D59B1837933E79178E08C0E3A402369D225C65F11BB9BCCEF70E622DC7901D118457BE01E54F1C4A3E6E22B21C9BF9353B2DEE68749C6F792AA213356044EA60C93AB4387BE9F0EA819FB6D355E72288DE46317644F90AF4317095E33AB130702308FA728FED2E1DD97ED472281C85C8B5FABA0A98EC6ED0EE80C0B851F9F562374C2B6A62BF41BD3213DFA6A7784F967BC5B8C24EF5B21995CFC47BB95342D7BD8BA6A77D7D981C5B262FE775AEF045BEE41A7B17F97131781550000024500004D000058988A520000%200000F1634CCCCCFF3A930BDF7E356FEB20D765F27CA0C418BDE97036C40E1C06D48BB111C979F1468FC033EC1ADF%20HAWK%20TX+RX+KSS%22
http://172.20.56.33:9200/filebeat*/_search?pretty=true&q="*xoxo*"
http://172.20.56.33:9200/filebeat*/_count?q=%22*xoxo*%22
http://172.20.56.33:9200/filebeat*/_count?q="*xoxo*"

::winform c# CURL 教學
https://blog.yslifes.com/archives/943
https://www.jb51.net/article/57156.htm
https://dotblogs.com.tw/yc421206/2013/11/11/127593
::20190226 httprequest
https://dotblogs.com.tw/yc421206/2013/11/11/127593
https://blog.yowko.com/webrequest-and-httpwebrequest/
https://stackoverflow.com/questions/2108297/how-to-get-json-response-using-system-net-webrequest-in-c

::Newtonsoft.Json.dll
https://dotblogs.com.tw/johnny/2014/05/04/intro-to-jsonnet
https://dotblogs.com.tw/shadow/2011/12/03/60576
https://blog.csdn.net/yingzhaom/article/details/53350456
http://www.cnblogs.com/txw1958/archive/2012/08/01/csharp-json.html


-------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace elastic
{
    class TEST
    {
        public void FUNCTION1(string http)
        {
            Console.WriteLine(">>> FUNCTION1 >>>");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(http);
            request.Method = WebRequestMethods.Http.Get;
            request.ContentType = "application/json";
            //雿輻 GetResponse ?寞?撠?request ?嚗????舐 using ??嚗?閮??? close WebResponse ?拐辣嚗?????鋡思??刻瘜?啁? request
            using (HttpWebResponse httpResponse = (HttpWebResponse)request.GetResponse())
            //雿輻 GetResponseStream ?寞?敺?server ??銝剖?敺???stream 敹?鋡恍???
            //雿輻 stream.close 撠勗隞亦?仿???WebResponse ??stream嚗???雿輻 using ????抵蒂銝????航炊嚗???????啣隞?憓?撠望?頛????
            using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                Console.WriteLine(result);
                //result.Dump();
            }

        }

        public void FUNCTION2(string http)
        {
            Console.WriteLine(">>> FUNCTION2 >>>");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(http);
            request.Method = WebRequestMethods.Http.Get;
            request.ContentType = "application/json";
            //雿輻 GetResponse ?寞?撠?request ?嚗????舐 using ??嚗?閮??? close WebResponse ?拐辣嚗?????鋡思??刻瘜?啁? request
            using (HttpWebResponse httpResponse = (HttpWebResponse)request.GetResponse())
            //雿輻JsonReader ??JsonTextReader
            using (JsonReader jReader = new JsonTextReader(new StreamReader(httpResponse.GetResponseStream())))
            {
                while (jReader.Read())
                {
                    Console.WriteLine(jReader.TokenType + "\t\t" + jReader.ValueType + "\t\t" + jReader.Value);
                    Console.WriteLine(jReader.Path);
                }

            }

        }

        public void FUNCTION3(string http)
        {
            Console.WriteLine(">>> FUNCTION3 >>>");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(http);
            request.Method = WebRequestMethods.Http.Get;
            request.ContentType = "application/json";
            //雿輻 GetResponse ?寞?撠?request ?嚗????舐 using ??嚗?閮??? close WebResponse ?拐辣嚗?????鋡思??刻瘜?啁? request
            HttpWebResponse httpResponse = (HttpWebResponse)request.GetResponse(); //撱箇????

            JsonReader jReader = new JsonTextReader(new StreamReader(httpResponse.GetResponseStream())); //撠??蝯夸son
            while (jReader.Read())
            {
                Console.WriteLine(jReader.TokenType + "\t\t" + jReader.ValueType + "\t\t" + jReader.Value);
                Console.WriteLine(jReader.Path);
            }

            jReader.Close();//??json
            httpResponse.Close(); //??connect

        }

        public void FUNCTION5(string http)
        {
            Console.WriteLine(">>> FUNCTION5 >>>");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(http);
            request.Method = WebRequestMethods.Http.Get;
            request.ContentType = "application/json";
            //雿輻 GetResponse ?寞?撠?request ?嚗????舐 using ??嚗?閮??? close WebResponse ?拐辣嚗?????鋡思??刻瘜?啁? request
            using (HttpWebResponse httpResponse = (HttpWebResponse)request.GetResponse())
            //雿輻JsonReader ??JsonTextReader
            using (JsonReader jReader = new JsonTextReader(new StreamReader(httpResponse.GetResponseStream())))
            {
                while (jReader.Read())
                {
                    if (jReader.Path == "count" && jReader.Path.ToString() != jReader.Value.ToString())
                    {
                        int ouptut = Convert.ToInt32(jReader.Value);
                        Console.WriteLine("total count:'{0}'",ouptut.ToString());

                        //Console.WriteLine(jReader.Value);

                    }

                }
            }

        }


        public int FUNCTION6(string http)
        {
            int itemlist = 999;

            Console.WriteLine(">>> FUNCTION6 >>>");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(http);
            request.Method = WebRequestMethods.Http.Get;
            request.ContentType = "application/json";
            //雿輻 GetResponse ?寞?撠?request ?嚗????舐 using ??嚗?閮??? close WebResponse ?拐辣嚗?????鋡思??刻瘜?啁? request
            using (HttpWebResponse httpResponse = (HttpWebResponse)request.GetResponse())
            //雿輻JsonReader ??JsonTextReader
            using (JsonReader jReader = new JsonTextReader(new StreamReader(httpResponse.GetResponseStream())))
            {
                while (jReader.Read())
                {
                    if (jReader.Path == "count" && jReader.Path.ToString() != jReader.Value.ToString())
                    {
                        itemlist = Convert.ToInt32(jReader.Value);

                    }

                }
            }
            return itemlist;
        }
    }

}


-------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using SCT.Tools;
using System.Data;
using System.IO;
//using System.Runtime.InteropServices;
//using Microsoft.Office.Interop.Excel;
//using System.Reflection;

namespace MSTAR_FT_LHS
{
    class FUNC
    {

        #region columns for Excel
        public string Columns;
        public string Values;
        public string type;
        //private object OPT = Missing.Value;
        #endregion coolums for Excel

        sctLog oLog = null;
        sctDBBase oOraDB = null;


        private List<List<TB_MSTAR_FT_LHS>> _lTB_MSTAR_FT_LHS = new List<List<TB_MSTAR_FT_LHS>>();

        /// <summary>
        /// 處理 TB_MSTAR_FT_LHS 格式 資料，並回傳list
        /// </summary>
        /// <param name="job"></param>
        /// <param name="sDebug"></param>
        /// <returns></returns
        private static List<TB_MSTAR_FT_LHS> MSTAR_FT_LHS(DataRow rows)
        {
            //初始化
            List<TB_MSTAR_FT_LHS> itemList = new List<TB_MSTAR_FT_LHS>();
            TB_MSTAR_FT_LHS _col = new TB_MSTAR_FT_LHS();
            _col.COMPANY = rows[0].ToString();
            _col.DOC_NO = rows[1].ToString();
            _col.LOT_NO = rows[2].ToString();
            _col.STAGE = rows[3].ToString();
            _col.LOT_TYPE = rows[4].ToString();
            _col.MFG = rows[5].ToString();
            _col.PRODUCT = rows[6].ToString();
            _col.FAMILY = rows[7].ToString();
            _col.RESPONSIBILITY = rows[8].ToString();
            _col.STATUS = rows[9].ToString();
            _col.DISPOSITION_DONE = rows[10].ToString();
            _col.VENDOR_SITE = rows[11].ToString();
            _col.MTK_OWNER = rows[12].ToString();
            _col.CREATE_DATE = rows[13].ToString();
            itemList.Add(_col);
            return itemList;
        }

        /// <summary>
        /// 從指定路徑取的Excel檔案內容 
        /// </summary>
        /// <param name="job"></param>
        /// <param name="sDebug"></param>
        /// <returns></returns>
        public List<string> GetRowData(LHS job, string fileName)
        {
            //初始化
            List<GetInfo> listInfo = new List<GetInfo>();
            DataSet TableSet = new DataSet();
            //string iSheetName = Convert.ToString("1");
            string iSheetName = "SCRIBE_NUMERIC_NAME";

            //初始化
            string Table_Name = job.TableName.Replace("_LINK_", "@"); //置換 "_" to "@"
            TableSet.Tables.Add(Table_Name);


            #region 取得XML設定EXCEL欄位X軸座
            //取得XML設定EXCEL欄位X軸座標
            foreach (string items in job.ConDition)
            {
                string[] XY = items.Split(',');
                GetInfo _col = new GetInfo();
                _col.TableName = Table_Name;
                _col.columns = XY[0].ToString();
                _col.X = XY[1];
                _col.type = XY[2].ToString();
                listInfo.Add(_col);
                if (_col.type.ToUpper() == "S" || _col.type.ToUpper() == "D")
                {
                    TableSet.Tables[Table_Name].Columns.Add(_col.columns, typeof(string));
                }
                else if (_col.type.ToUpper() == "I")
                {
                    TableSet.Tables[Table_Name].Columns.Add(_col.columns, typeof(int));
                }
            }
            #endregion 取得XML設定EXCEL欄位X軸座


            //// 準備物件列表 
            List<string> itemList = new List<string>();

            // 開始組insert_SQL
            #region 開始組insert_SQL
            sctExcel objExcel = new sctExcel(); //開啟exporrt excel 模板
            int intCurrentRow = 2;

            #region old
            //OPEN FILE FOR GET DATA
            #region OPEN FILE FOR GET DATA
            job.Log.LogInfo(">>> 開檔: " + fileName);
            job.Log.LogInfo(">>> GET data from FIEL(" + job.Deputy_Name + ") ");

            //開啟Excle 檔案
            objExcel.Open(fileName);

            //判斷是否為最後一行，如果是最後一行則bolEof = true
            bool bolEOF = false;

            while (bolEOF == false)
            {
                // 先 check 要處理的這筆資料是否是空的 
                //string strTemp = objExcel.GetCellValue(iSheetName, intCurrentRow, 1).Trim();
                string strTemp = objExcel.GetCellValue(1, intCurrentRow, 1).Trim();
                if (String.IsNullOrEmpty(strTemp))
                {
                    intCurrentRow = 2;
                    bolEOF = true;

                }
                else
                {
                    foreach (DataTable itemColumns in TableSet.Tables)
                    {
                        DataRow Rows = itemColumns.NewRow();

                        foreach (GetInfo list in listInfo)
                        {
                            if (list.TableName != itemColumns.TableName)
                            {
                                break; //如果tablename 不相符就離開
                            }
                            if (list.type.ToUpper() == "S" || list.type.ToUpper() == "I")
                            {
                                FUNC item = new FUNC();
                                item.Columns = list.columns;
                                item.type = list.type;
                                //item.Values = objExcel.GetCellValue(iSheetName, intCurrentRow, Convert.ToInt16(list.X));
                                item.Values = objExcel.GetCellValue(1, intCurrentRow, Convert.ToInt16(list.X));
                                Rows[item.Columns] = item.Values;
                            }
                            else if (list.type.ToUpper() == "D")
                            {
                                FUNC item = new FUNC();
                                item.Columns = list.columns;
                                item.type = list.type;
                                item.Values = list.X;                //從xml取值下來
                                Rows[item.Columns] = item.Values;
                            }
                        }

                        itemColumns.Rows.Add(Rows);
                    }
                    intCurrentRow++;

                }
            }
            job.Log.LogInfo(">>> 關檔: " + fileName);
            // 關檔
            objExcel.Close();
            objExcel.Dispose();
            #endregion OPEN FILE FOR GET DATA

            #endregion old


            #region new
            //Application Excel_APP = new Application();
            //Workbook Excel_book = Excel_APP.Workbooks.Open(fileName, OPT, OPT, OPT, OPT, OPT, OPT, OPT, OPT, OPT, OPT, OPT, OPT, OPT, OPT);//開啟exporrt excel 模板
            //int SheetName = 1;
            //Worksheet Excel_Sheet = (Worksheet)Excel_APP.Sheets["LHS"]; //指定sheet name
            ////  Excel_APP.Cells[y, 1] = item.SUPPLIER_NAME;
            ////Range range1 = Excel_Sheet.get_Range("P1", "P" + total_count.ToString());
            //string test = (Excel_Sheet.Cells[2, 14] as Range).Text.ToString();
            ////Range raOne = (Range)Excel_Sheet.Cells[2, 14];
            ////raOne.Columns.AutoFit();     //自動調整欄位寬度1
            //raOne.EntireColumn.AutoFit();  //自動調整欄位寬度2
            //raOne.NumberFormat = @"yyyy/MM/dd HH:mm:ss";
            //objExcel.GetCellValue();
            //objExcel.Dispose();
            //Excel_Sheet = null;
            //Excel_book = null;
            //Excel_APP.DisplayAlerts = false;
            //Excel_APP.Workbooks.Close();
            //Excel_APP.Quit();
            //System.Runtime.InteropServices.Marshal.FinalReleaseComObject(Excel_APP);
            //GC.Collect();
            //GC.WaitForPendingFinalizers();


        //public string GetCellValue(object sourceSheet, int posY, int posX)
        //{
        //    Worksheet objSheet = (Worksheet)m_Excel.Sheets[sourceSheet];
        //    (objSheet.Cells[posY, posX] as Range).EntireColumn.AutoFit();//自動調整欄位寬度
        //    return (objSheet.Cells[posY, posX] as Range).Text.ToString();
        //}
            #endregion  new


            //處理TB_MSTAR_FT_LHS 格式至list
            #region 處理TB_MSTAR_FT_LHS 格式至list
            foreach (DataRow Rows in TableSet.Tables["TB_MSTAR_FT_LHS"].Rows)
            {
                _lTB_MSTAR_FT_LHS.Add(FUNC.MSTAR_FT_LHS(Rows));
            }
            #endregion 處理TB_MSTAR_FT_LHS 格式至list

            //組合INSERT SQL
            #region 組合INSERT SQL
            //TB_MSTAR_FT_LHS
            foreach (List<TB_MSTAR_FT_LHS> Rows in _lTB_MSTAR_FT_LHS)
            {
                TB_MSTAR_FT_LHS items = new TB_MSTAR_FT_LHS();

                foreach (TB_MSTAR_FT_LHS row in Rows)
                {
                    string _sSQL = "Insert into TB_MSTAR_FT_LHS ( COMPANY,DOC_NO,LOT_NO,STAGE,LOT_TYPE,MFG,PRODUCT,FAMILY,RESPONSIBILITY,STATUS,DISPOSITION_DONE,VENDOR_SITE,MTK_OWNER,CREATE_DATE,UPDATE_TIME ) Values (";
                    _sSQL += "'" + row.COMPANY + "','" + row.DOC_NO + "','" + row.LOT_NO + "','" + row.STAGE + "','" + row.LOT_TYPE + "','" + row.MFG + "','" + row.PRODUCT + "','" + row.FAMILY + "','" + row.RESPONSIBILITY + "','" + row.STATUS + "','" + row.DISPOSITION_DONE + "','" + row.VENDOR_SITE + "','" + row.MTK_OWNER + "','" + row.CREATE_DATE + "', SYSDATE)";
                    itemList.Add(_sSQL);

                    if (job.sDebug == true)
                    {
                        job.Log.LogDebug(">>> " + _sSQL);
                        Console.WriteLine(_sSQL);
                    }

                }
            }
            #endregion 組合INSERT SQL

            #endregion 開始組insert_SQL


            return itemList;
        }

        /// <summary>
        /// 抄寫至DB 
        /// </summary>
        /// <param name="job"></param>
        /// <param name="sDebug"></param>
        /// <returns></returns>
        public string InsertDB(sctDBBase db, LHS job, List<string> SQL)
        {
            string strMsg = "";
            try
            {
                db.TxnBegin(); // begin
                foreach (string sSQL in SQL)
                {
                    db.Execute(sSQL); //insert DB
                }
                db.TxnCommit(); // commint
            }
            catch (Exception ex)
            {
                db.TxnRollback(); //Exceiption to rollback data
                job.Log.LogError(ex);

                strMsg += " NUMERIC File insert db error :" + ex.Message + Environment.NewLine;
            }

            return strMsg;
        }

    }
}

-------------------------------------------------------------------------
'AUTOIT IE FORM
http://www.autoitx.com/UDF/index.htm?page=html%2Flibfunctions%2F_iecreate.htm
http://www.autoitx.com/
https://www.autoitscript.com/site/autoit/downloads/
https://www.autoitscript.com/autoit3/docs/appendix/SendKeys.htm\
https://www.autoitscript.com/forum/topic/179156-how-to-auto-login-a-web-page-on-local-nas-using-ie/
http://yhhuang1966.blogspot.com/2018/05/autoit_61.html
             
Dim = Local scope if the variable name doesn't already exist globally (in which case it reuses the global variable!)
Global = Forces creation of the variable in the Global scope
Local = Forces creation of the variable in the Local/Function scope
             
'SAMPLE1
#include <IE.au3>
_IEErrorHandlerRegister()  ;註冊並使用一個自定義COM錯誤處理程序.

;;login 
Local $oIE1 = _IECreate ("http://wsbmesweb01:8088/Login/LoginForm.aspx")
local $username = _IEGetObjByName ($oIE1,"txt_User_ID")
local $password = _IEGetObjByName ($oIE1,"txt_Pw")
local $enter    = _IEGetObjByName ($oIE1,"btn_Login")
_IEFormElementSetValue ($username, "rychenga")
_IEFormElementSetValue ($password, "rychenga")
_IEAction($enter, "click")
_IELoadWait ($oIE1, 300)
Sleep(100)

;;NEXT Web Page
_IENavigate($oIE1, "http://wsbmesweb01:8088/Setup/frmViewClassMember.aspx")
_IELoadWait ($oIE1, 300)

;BU (dropdown list)
Local $oForm = _IEFormGetObjByName ($oIE1, "aspnetForm")                                        ;"form name"
Local $oSelect = _IEFormElementGetObjByName ($oForm, "ctl00$ContentPlaceHolder1$Drop_BU")       ;"select name"
;_IEFormElementOptionselect ($oSelect, 3, 1, "byIndex")
;_IEFormElementOptionselect ($oSelect, "All", 1, "byText")
_IEFormElementOptionselect ($oSelect, "TEST", 1, "byValue")
_IELoadWait ($oIE1, 300)

;課程類別(dropdown list)
Local $oSelect = _IEFormElementGetObjByName (_IEFormGetObjByName ($oIE1, "aspnetForm"), "ctl00$ContentPlaceHolder1$Drop_Course_Category_ID")       ;"select name"
_IEFormElementOptionselect ($oSelect, "ARC", 1, "byValue")
_IELoadWait ($oIE1, 300)

;課程中文 (TEXT)
local $ctl00_ContentPlaceHolder1_txt_Course_Desc_CH = _IEGetObjByName ($oIE1,"ctl00_ContentPlaceHolder1_txt_Course_Desc_CH")
_IEFormElementSetValue ($ctl00_ContentPlaceHolder1_txt_Course_Desc_CH, "TARC0045")
_IELoadWait ($oIE1, 300)

;搜尋 (button)
Local $serach  = _IEGetObjByName ($oIE1,"ctl00_ContentPlaceHolder1_btnSearch")
_IEAction($serach, "click")
_IELoadWait ($oIE1, 300)

;請選擇課程代碼 (dropdown list)
Local $oSelect = _IEFormElementGetObjByName (_IEFormGetObjByName ($oIE1, "aspnetForm"), "ctl00$ContentPlaceHolder1$Drop_Select_CourseID")       ;"select name"
_IEFormElementOptionselect ($oSelect, "TARC0045", 1, "byValue")
_IELoadWait ($oIE1, 300)

;請選擇已開課班級 (dropdown list)
Local $oSelect = _IEFormElementGetObjByName (_IEFormGetObjByName ($oIE1, "aspnetForm"), "ctl00$ContentPlaceHolder1$Drop_Select_ClassID")       ;"select name"
_IEFormElementOptionselect ($oSelect, "TARC0045_20180905152359", 1, "byValue")
_IELoadWait ($oIE1, 300)

;登出
Local $exit  = _IEGetObjByName ($oIE1,"ctl00_Menu1n5")
_IEAction($exit, "click")
_IELoadWait ($oIE1, 300)


;關閉網頁
_IEQuit($oIE1)
SLEEP(500)

;離開AutoIt3
Exit

::InetGet
::_IELinkClickByText

'SAMPLE2
#include <IE.au3>
_IEErrorHandlerRegister()  ;註冊並使用一個自定義COM錯誤處理程序.

;;開新網頁
;Opt ("MustDeclareVars", 1)
;Global Const $ie_new_in_tab = 0x0800
;Local $oIE2 = _IECreateTab ($oIE1, "http://wsbmesweb01:8088/Setup/frmViewClassMember.aspx")

;;login 
Local $oIE1 = _IECreate ("http://wsbmesweb01:8088/Login/LoginForm.aspx")
;Call("SingIn")
SingIn($oIE1)  ;login

;;NEXT Web Page
Local $oIE2 = _IENextPage($oIE1,"http://wsbmesweb01:8088/Setup/frmViewClassMember.aspx");

;BU (dropdown list)
_DropDownSet($oIE2,"ctl00$ContentPlaceHolder1$Drop_BU","TEST")


;課程類別(dropdown list)
_DropDownSet($oIE2,"ctl00$ContentPlaceHolder1$Drop_Course_Category_ID","ARC")

;課程中文 (TEXT)
_TEXTSet($oIE2,"ctl00_ContentPlaceHolder1_txt_Course_Desc_CH","TARC0045")

;搜尋 (button)
_Button($oIE2,"ctl00_ContentPlaceHolder1_btnSearch")

;請選擇課程代碼 (dropdown list)
_DropDownSet($oIE2,"ctl00$ContentPlaceHolder1$Drop_Select_CourseID","TARC0045")

;請選擇已開課班級 (dropdown list)
_DropDownSet($oIE2,"ctl00$ContentPlaceHolder1$Drop_Select_ClassID","TARC0045_20180905152359")

;登出
Logout($oIE2)

;關閉網頁
_IEQuit($oIE1)
SLEEP(500)

;離開AutoIt3
Exit


;;New Web Page in another Web Page
Func _IECreateTab (ByRef $oIE, $url)
Local $Count = 0, $oIE2

  $oIE.Navigate ($url, $ie_new_in_tab)

  While 1
    $oIE2 = _IEAttach($url, "url")
    If IsObj($oIE2) Then ExitLoop
    $Count += 1
    if $Count > 100 then Exit MsgBox (0,"Error","Load expired")
    Sleep (50)
  WEND

  _IELoadWait ($oIE2, 300)
  return $oIE2

EndFunc

;;login funcion
Func SingIn(ByRef $oIE)
	 Local $username = _IEGetObjByName ($oIE,"txt_User_ID")
	 Local $password = _IEGetObjByName ($oIE,"txt_Pw")
	 Local $enter    = _IEGetObjByName ($oIE,"btn_Login")	 
	 _IEFormElementSetValue ($username, "rychenga")
	 _IEFormElementSetValue ($password, "rychenga")
	 _IEAction($enter, "click")
     _IELoadWait ($oIE, 300)
	 Return $oIE	 
EndFunc

;;NEXT Web Page
Func _IENextPage(ByRef $oIE, $url)
    _IENavigate($oIE, $url)   ;切換網頁
	_IELoadWait ($oIE, 300)
	Return $oIE
	;MsgBox(4096, "The URL2", _IEPropertyGet($oIE, "locationurl"))
EndFunc

;;DropDown list
Func _DropDownSet(ByRef $oIE,$oSelect_Name,$input)
      ;Local $oForm = _IEFormGetObjByName ($oIE, "aspnetForm")                ;"form name"
	  ;Local $oSelect = _IEFormElementGetObjByName ($oForm, $oSelect_Name)    ;"select name"
	  ;$iOptionCount = $oSelect.length
	  ;ConsoleWrite("Length = " & $iOptionCount & @LF)
      ;For $i = 1 To 10
      ;   For $n = 0 To $iOptionCount - 1
      ;       _IEFormElementOptionselect ($oSelect, $n, 1, "byIndex")
      ;        Sleep(1000)
      ;   Next
      ;Next
      ;_IEFormElementOptionselect ($oSelect, 3, 1, "byIndex")
      ;_IEFormElementOptionselect ($oSelect, "All", 1, "byText")
	  Local $oSelect = _IEFormElementGetObjByName (_IEFormGetObjByName ($oIE, "aspnetForm"), $oSelect_Name)	  
	  _IEFormElementOptionSelect($oSelect, $input, 1, "byValue")	  
	  _IELoadWait ($oIE, 300)
	  Return $oIE
EndFunc

;;TEXT INPUT
Func _TEXTSet(ByRef $oIE,$oID_Name,$input)
     _IEFormElementSetValue (_IEGetObjByName ($oIE,$oID_Name), $input)
     _IELoadWait ($oIE, 300)
	 Return $oIE
EndFunc

;;Button
Func _Button(ByRef $oIE,$oID_Name)
     _IEAction(_IEGetObjByName ($oIE,$oID_Name), "click")
     _IELoadWait ($oIE, 300)
	 Return $oIE
EndFunc

;;logout function
Func Logout(ByRef $oIE)
     Local $oLinks, $oForm, $sURL, $iFlag = 0

     $oLinks = _IETagNameGetCollection($oIE, "a")
     If @error Then Exit 1

     $iFlag = 0
     For $oLink In $oLinks
         If StringInStr(_IEPropertyGet($oLink, "outertext"), "Logout") > 0 Then
             $iFlag = 1
             _IEAction($oLink, "focus")
             _IEAction($oLink, "click")
             ExitLoop
         EndIf
     Next
     If Not $iFlag Then Exit 2
	 _IELoadWait ($oIE, 3000)
	 Return $oIE
EndFunc
-------------------------------------------------------------------------
'AUTOIT 網址 for CSS Question
 https://www.autoitscript.com/forum/search/?q=Get%20IE%20element%20by%20CSS
 https://www.autoitscript.com/forum/topic/190619-get-ie-element-by-cssselector/
 https://www.autoitscript.com/forum/topic/197738-solved-ie-element-with-an-existing-id-cant-be-found/
 https://www.autoitscript.com/forum/topic/190906-solved-ie-set-value-in-an-input-without-a-form-tag/
 
https://www.autoitscript.com/forum/topic/49205-how-to-get-access-to-elements-embedded-in-a-iframe/
https://stackoverflow.com/questions/6204021/get-form-name-from-iframe-using-autoit/
https://www.autoitscript.com/autoit3/docs/functions/ClipPut.htm
ClipPut($TEXT)
Send("^v")
https://www.autoitscript.com/forum/topic/72281-can-use-help-with-_ieformgetobjbyname/
https://www.autoitscript.com/forum/topic/116674-help-to-get-ie-iframe-source/
https://stackoverflow.com/questions/23020796/autoit-access-and-simulate-click-link-in-iframe-of-website?rq=1
::03/23
:: Auto jquery _IEFormcolletion or _IETAGcollection
https://www.autoitscript.com/forum/topic/185383-ie-11-automatic-using-jquery/
https://www.autoitscript.com/forum/topic/81025-ie-automation-using-jquery/
https://www.autoitscript.com/forum/topic/190115-jquery-in-ie/
::ie.au3 jquery
https://www.autoitscript.com/forum/topic/197717-browser-automation-for-select2-dropdown-search-and-select/?tab=comments#comment-1418244
https://www.autoitscript.com/forum/topic/197717-browser-automation-for-select2-dropdown-search-and-select/?tab=comments#comment-1418243
https://www.autoitscript.com/forum/topic/195349-how-to-code-it-using-autoit/?tab=comments#comment-1400734 
https://www.autoitscript.com/forum/topic/195009-ie_-action-by-click/?tab=comments#comment-1398555
https://www.autoitscript.com/forum/topic/191939-jquerify-a-web-page-injecting-jquery/?tab=comments#comment-1377088
https://www.autoitscript.com/forum/topic/191939-jquerify-a-web-page-injecting-jquery/page/2/?tab=comments#comment-1387944
:: 認為直接在HTML崁入 id="名稱" ，可能還比較快
https://www.w3schools.com/jquery/tryit.asp?filename=tryjquery_dom_val_get
https://www.w3schools.com/jquery/tryit.asp?filename=tryjquery_dom_attr_get
::
https://jingyan.baidu.com/article/9989c74604d644f648ecfe03.html
https://www.cnblogs.com/zhaojin/archive/2011/01/26/1945799.html
https://stackoverflow.com/questions/24970772/pass-information-from-javascript-to-autoit
https://www.autoitscript.com/forum/topic/191939-jquerify-a-web-page-injecting-jquery/
::0325
http://www.jianyiit.com/post-296.html
::0326
https://www.autoitscript.com/forum/topic/195349-how-to-code-it-using-autoit/?tab=comments#comment-1400734
-------------------------------------------------------------------------
'掃所有tagname
#include <IE.au3>
#include <Date.au3>
#include <MsgBoxConstants.au3>
#include <FileConstants.au3>
#include <WinAPIFiles.au3>

_IEErrorHandlerRegister()  ;regest error message

Local $Url = $CmdLine[1]


;write log file
Local $logtxt =  FileOpen("D:\Temp\Taglist.txt",$FO_APPEND)
; Delete the temporary file.
FileDelete($logtxt)
FileWriteLine($logtxt,">>> start "&  _DateTimeFormat(_NowCalc(), 0) &">>>")
Local $oIE = _IECreate ($Url)

FileWriteLine($logtxt,">>> ---------------------------------- Tags iframes -------------------------------------------------- >>>" &  _DateTimeFormat(_NowCalc(), 0) & @CRLF)
Local $Main_iForms = _IEFrameGetCollection($oIE) ;<--------
FileWriteLine($logtxt,">>> ObjName =[" & $Main_iForms.name & "] ID =[" & $Main_iForms.id & "]")
Local $oElements = _IETagNameAllGetCollection($Main_iForms)
Local $TagN = @extended
FileWriteLine($logtxt,">>> number of $oIE Tags = " & @extended)
FileWriteLine($logtxt,">>> number of $oIE Tags = " & $TagN)
For $i = 0 To ($TagN - 1)
	Local $oElement =  _IETagNameAllGetCollection($Main_iForms,$i)
	FileWriteLine($logtxt, ">>> [" & $i & "]Info Tagname:[" & $oElement.tagname & "] id:[" & $oElement.id & "] role:["& $oElement.role & "] Class:[" & $oElement.GetAttribute("class") & "]"& @CRLF)

	;IF $oElement.tagname  = "BUTTON" Then
		;FileWriteLine($logtxt, ">>> [" & $i & "]Info Tagname:[" & $oElement.tagname & "] id:[" & $oElement.id & "] role:["& $oElement.role & "] Class:[" & $oElement.GetAttribute("class") & "]"& @CRLF)
	;EndIf

Next

FileWriteLine($logtxt,">>> ---------------------------------- END -------------------------------------------------- >>>" &  _DateTimeFormat(_NowCalc(), 0) & @CRLF)
;Local $FramUrl = _IEPropertyGet($oFrame, "locationurl")
;Local $innerthtml = _IEPropertyGet($oIE, "innerhtml")
;FileWriteLine($logtxt,$innerthtml)
FileWriteLine($logtxt,">>> ---------------------------------- END -------------------------------------------------- >>>" &  _DateTimeFormat(_NowCalc(), 0) & @CRLF)
Local $oIE3_Html = _IEDocReadHTML($oIE) ;get doc html
FileWriteLine($logtxt,$oIE3_Html)
FileWriteLine($logtxt,">>> ---------------------------------- END -------------------------------------------------- >>>" &  _DateTimeFormat(_NowCalc(), 0) & @CRLF)



FileClose($logtxt) ; close log files
_IEQuit($oIE)
Exit ;Exit AutoIt3

-------------------------------------------------------------------------
#include <IE.au3>
#include <Date.au3>
#include <MsgBoxConstants.au3>
#include <FileConstants.au3>
#include <WinAPIFiles.au3>

_IEErrorHandlerRegister()  ;regest error message

;get now time
;Local $DateTime = _DateTimeFormat(_NowCalc(), 0)

;Local $DownPath =  "%userprofile%\Downloads\ExportLHS.xlsx"
Local $DownPath =  "C:\Users\Jeff.Cheng\Downloads\ExportLHS.xlsx"
;Local $FileName = "ExportLHS.xlsx"
Local $ToPath = "D:\Temp\XLSX\"


;$CmdLine[nth] ; The nth parameter e.g. 10 if the array contains 10 items.
;$CmdLineRaw ; This contains myScript.au3 param1 "This is a string parameter" 99.
;Local $ac = $CmdLine[1]
;Local $pw = $CmdLine[2]
;MsgBox(0,"","account:[" & $ac & "] password:[" & $pw & "]")
Local $ilot_no = $CmdLine[1]
;MsgBox(0,"","input:[" & $ilot_no & "]")

;write log file
Local $logtxt =  FileOpen("D:\Temp\log.txt",$FO_APPEND)
FileWriteLine($logtxt,">>> start "&  _DateTimeFormat(_NowCalc(), 0) &">>>")
Local $oIE = _IECreate ("http://xxxxxxxxxxxxxxxxxxxx")
SingIn($oIE,"bbbbb","aaaa")  ;login

_IENavigate($oIE,"http://mtkspapp.mediatek.com/lh")
_IELoadWait ($oIE, 3000)
BlockInput(True) ;限制任何外部輸入
Local $hWnd = WinWait("LH - Internet Explorer", "", 10)
WinActivate($hWnd)

;Reset
Local $BReset_Button = _IETagNameGetCollection($oIE, "DIV",98)
_IEAction($BReset_Button,"click");
_IELoadWait ($oIE, 300)

;Reset in Create
;Local $Create_Button  = _IETagNameGetCollection($oIE, "DIV",39)
;_IEAction($Create_Button,"click")
;_IELoadWait ($oIE, 300)
;Sleep(1000)
;Send("{TAB}")
;Sleep(1000)
;Send($ilot_no)
;Sleep(1000)

;主程式
;select lot no
Local $BQuery_Button  = _IETagNameGetCollection($oIE, "DIV",59)
_IEAction($BQuery_Button,"click")
_IELoadWait ($oIE, 300)
Send("{PGUP 2}")
Sleep(1000)
Send("{DOWN 2}")
Sleep(1000)
Send("{ENTER 2}")
Sleep(1000)
Send("{TAB 2}")
Sleep(1000)

;input lot no
Local $oInput  = _IETagNameGetCollection($oIE, "input",3)
;_IEFormElementSetValue($oInput, "rychenga")
_IEFormElementSetValue($oInput, $ilot_no)
_IELoadWait ($oIE, 300)
Sleep(1000)
Send("{ENTER 2}")
Sleep(1000)


;Link download
Local $BReset_Button = _IETagNameGetCollection($oIE, "DIV",119)
_IEAction($BReset_Button,"click");
_IELoadWait ($oIE, 300)
Sleep(1000)
Send("!s")
Sleep(1000)



FileClose($logtxt)

;Local $hWnd = WinWait("LH - Internet Explorer", "", 10)
;WinActivate($hWnd)
WinClose($hWnd)
BlockInput(False);解除所有外部輸入

;$FC_NOOVERWRITE (0) = (default) do not overwrite existing files.
;$FC_OVERWRITE (1) = overwrite existing files.
;$FC_CREATEPATH (8) = Create destination directory structure if it doesn't exist (See Remarks).
FileMove($DownPath,$ToPath,1)
;Msgbox(0,"","Proecess End")

Exit ;Exit AutoIt3



;;New Web Page in another Web Page
Func _IECreateTab (ByRef $oIE, $url)
Local $Count = 0, $oIE2

  $oIE.Navigate ($url, $ie_new_in_tab)

  While 1
    $oIE2 = _IEAttach($url, "url")
    If IsObj($oIE2) Then ExitLoop
    $Count += 1
    if $Count > 100 then Exit MsgBox (0,"Error","Load expired")
    Sleep (50)
  WEND

  _IELoadWait ($oIE2, 300)
  return $oIE2

EndFunc

;;login funcion
Func SingIn(ByRef $oIE,$user,$paw)
	 Local $username = _IEGetObjByName ($oIE,"j_username")
	 Local $password = _IEGetObjByName ($oIE,"j_password")
	 Local $enter    = _IEGetObjByName ($oIE,"uidPasswordLogon")
	 _IEFormElementSetValue ($username, $user)
	 _IEFormElementSetValue ($password, $paw)
	 _IEAction($enter, "click")
     _IELoadWait ($oIE, 3000)
	 Return $oIE
EndFunc

;;NEXT Web Page
Func _IENextPage(ByRef $oIE, $url)
    _IENavigate($oIE, $url)   ;????
	_IELoadWait ($oIE, 300)
	Return $oIE
	;MsgBox(4096, "The URL2", _IEPropertyGet($oIE, "locationurl"))
EndFunc

;;DropDown list
Func _DropDownSet(ByRef $oIE,$oSelect_Name,$input)
      ;Local $oForm = _IEFormGetObjByName ($oIE, "aspnetForm")                ;"form name"
	  ;Local $oSelect = _IEFormElementGetObjByName ($oForm, $oSelect_Name)    ;"select name"
	  ;$iOptionCount = $oSelect.length
	  ;ConsoleWrite("Length = " & $iOptionCount & @LF)
      ;For $i = 1 To 10
      ;   For $n = 0 To $iOptionCount - 1
      ;       _IEFormElementOptionselect ($oSelect, $n, 1, "byIndex")
      ;        Sleep(1000)
      ;   Next
      ;Next
      ;_IEFormElementOptionselect ($oSelect, 3, 1, "byIndex")
      ;_IEFormElementOptionselect ($oSelect, "All", 1, "byText")
	  Local $oSelect = _IEFormElementGetObjByName (_IEFormGetObjByName ($oIE, "aspnetForm"), $oSelect_Name)
	  _IEFormElementOptionSelect($oSelect, $input, 1, "byValue")
	  _IELoadWait ($oIE, 300)
	  Return $oIE
EndFunc

;;TEXT INPUT
Func _TEXTSet(ByRef $oIE,$oID_Name,$input)
     _IEFormElementSetValue (_IEGetObjByName ($oIE,$oID_Name), $input)
     _IELoadWait ($oIE, 300)
	 Return $oIE
EndFunc

;;Button
Func _Button(ByRef $oIE,$oID_Name)
     _IEAction(_IEGetObjByName ($oIE,$oID_Name), "click")
     _IELoadWait ($oIE, 300)
	 Return $oIE
EndFunc

;;logout function
Func _Logout(ByRef $oIE)
     Local $oLinks, $oForm, $sURL, $iFlag = 0

     $oLinks = _IETagNameGetCollection($oIE, "a")
     If @error Then Exit 1

     $iFlag = 0
     For $oLink In $oLinks
         If StringInStr(_IEPropertyGet($oLink, "outertext"), "Logout") > 0 Then
             $iFlag = 1
             _IEAction($oLink, "focus")
             _IEAction($oLink, "click")
             ExitLoop
         EndIf
     Next
     If Not $iFlag Then Exit 2
	 _IELoadWait ($oIE, 3000)
	 Return $oIE
EndFunc

Func _jQuerify(ByRef $oIE)

    Local $msie, $jsEval, $jQuery, $otherlib = False

    $msie = Execute('$oIE.document.documentMode')

    If ($msie = "") Or Number($msie) < 11 Then ; an IE version < 11
        ; create a reference to the javascript eval() function
        $oIE.document.parentWindow.setTimeout('window.eval = eval', 0)
        Do
            Sleep(250)
            $jsEval = Execute('$oIE.Document.parentwindow.eval')
        Until IsObj($jsEval)

    Else ; IE version > = 11
        ; create a reference to the javascript eval() function
        $oIE.document.parentWindow.setTimeout('document.head.eval = eval', 0)
        Do
            Sleep(250)
            $jsEval = Execute('$oIE.Document.head.eval')
        Until IsObj($jsEval)

    EndIf

    ; if jQuery is not already loaded then load it
    If $jsEval("typeof jQuery=='undefined'") Then

        ; check if the '$' (dollar) name is already in use by other library
        If $jsEval("typeof $=='function'") Then $otherlib = True

        Local $oScript = $oIE.document.createElement('script');
        $oScript.type = 'text/javascript'

        ; If you want to load jQuery from a disk file use the following statement
        ; where i.e. jquery-1.9.1.js is the file containing the jQuery source
        ; (or also use a string variable containing the whole jQuery listing)
        ;~ $oScript.TextContent = FileRead(@ScriptDir & "\jquery-1.9.1.js") ; <--- from a file
		$oScript.TextContent = FileRead(@ScriptDir & "\jquery-3.3.1.min.js") ;

        ; If you want to download jQuery from the web use this statement
        ;$oScript.src = 'https://code.jquery.com/jquery-latest.min.js' ; <--- from an url


        $oIE.document.getElementsByTagName('head').item(0).appendChild($oScript)
        Do
            Sleep(250)
        Until $jsEval("typeof jQuery == 'function'")
    EndIf

    Do
        Sleep(250)
        $jQuery = $jsEval("jQuery")
    Until IsObj($jQuery)

    If $otherlib Then $jsEval('jQuery.noConflict();')

    Return $jQuery
EndFunc   ;==>_jQuerify
-------------------------------------------------------------------------
#include <IE.au3>
#include <Date.au3>
#include <MsgBoxConstants.au3>
#include <FileConstants.au3>
_IEErrorHandlerRegister()  ;regest error message

$oIE = _IECreate("https://www.hkex.com.hk/Market-Data/Futures-and-Options-Prices/Equity-Index/Hang-Seng-Index-Futures-and-Options?sc_lang=en#&product=HSI")
MsgBox(0,"pause","Press ok when page is ready")

$jQuery = _jQuerify($oIE)
$jQuery('.sewvbm > li:nth-child(2)').click()
_IELoadWait ($oIE, 300)

Msgbox(0,"","Proecess End")
;_IEQuit($oIE)
;Exit AutoIt3
Exit



Func _jQuerify(ByRef $oIE)

    Local $msie, $jsEval, $jQuery, $otherlib = False

    $msie = Execute('$oIE.document.documentMode')

    If ($msie = "") Or Number($msie) < 11 Then ; an IE version < 11
        ; create a reference to the javascript eval() function
        $oIE.document.parentWindow.setTimeout('window.eval = eval', 0)
        Do
            Sleep(250)
            $jsEval = Execute('$oIE.Document.parentwindow.eval')
        Until IsObj($jsEval)

    Else ; IE version > = 11
        ; create a reference to the javascript eval() function
        $oIE.document.parentWindow.setTimeout('document.head.eval = eval', 0)
        Do
            Sleep(250)
            $jsEval = Execute('$oIE.Document.head.eval')
        Until IsObj($jsEval)

    EndIf

    ; if jQuery is not already loaded then load it
    If $jsEval("typeof jQuery=='undefined'") Then

        ; check if the '$' (dollar) name is already in use by other library
        If $jsEval("typeof $=='function'") Then $otherlib = True

        Local $oScript = $oIE.document.createElement('script');
        $oScript.type = 'text/javascript'

        ; If you want to load jQuery from a disk file use the following statement
        ; where i.e. jquery-1.9.1.js is the file containing the jQuery source
        ; (or also use a string variable containing the whole jQuery listing)
        ;~ $oScript.TextContent = FileRead(@ScriptDir & "\jquery-1.9.1.js") ; <--- from a file
		$oScript.TextContent = FileRead(@ScriptDir & "\jquery-3.3.1.min.js") ;

        ; If you want to download jQuery from the web use this statement
        ;$oScript.src = 'https://code.jquery.com/jquery-latest.min.js' ; <--- from an url


        $oIE.document.getElementsByTagName('head').item(0).appendChild($oScript)
        Do
            Sleep(250)
        Until $jsEval("typeof jQuery == 'function'")
    EndIf

    Do
        Sleep(250)
        $jQuery = $jsEval("jQuery")
    Until IsObj($jQuery)

    If $otherlib Then $jsEval('jQuery.noConflict();')

    Return $jQuery
EndFunc   ;==>_jQuerify
-------------------------------------------------------------------------
::VS 2010 常用熱鍵
為了怕自己忘記，記錄一下VS 2010 中程式碼展開跟縮起來的快捷鍵
展開：Ctrl (不放) + M + L
縮合：Ctrl (不放) + M + H
大綱縮合：Ctrl (不放) + M + O
大綱展開：Ctrl (不放) + M + M
CTRL + K CTRL + D 將整份文件的程式碼自動排版

:::C# 小用法
::方法一
        public enum enExcelCol
        {
            /// <summary>
            /// column A
            /// </summary>
            Lotid=1,   <--定義啟始值，後面自動連續下去
            /// <summary>
            /// column B
            /// </summary>
            description, //2
            colNew,
            dd,
            saa,
            ff
        }
		
		Description += objExcel.GetCellValue(iSheetName, iLine++, (int)enExcelCol.Lotid).Trim();

::如果一次要連續抓好幾個欄位的值
int iLine = 13;
                Description += objExcel.GetCellValue(iSheetName, iLine++, 1).Trim();
                Description += objExcel.GetCellValue(iSheetName, iLine++, 1).Trim();
                Description += objExcel.GetCellValue(iSheetName, iLine++, 1).Trim();
                Description += objExcel.GetCellValue(iSheetName, iLine++, 1).Trim();
                Description += objExcel.GetCellValue(iSheetName, iLine++, 1).Trim();
                Description += objExcel.GetCellValue(iSheetName, iLine++, 1).Trim();		
		
-------------------------------------------------------------------------
WinSetState($hWnd, "", @SW_SHOW) ; Set the state of the Notepad window to "show".
Sleep(2000)
Local $BSave = WinWait("File Download", "", 10) ; lock IE GUI
WinSetState($BSave, "", @SW_SHOW) ; Set the state of the Notepad window to "show".
ControlClick($BSave, "", "[CLASS:Button; INSTANCE:2]") ;Click Save
Sleep(2000)
Local $BSave = WinWait("另存新檔", "", 10) ; lock IE GUI
WinSetState($BSave, "", @SW_SHOW) ; Set the state of the Notepad window to "show".
ControlClick($BSave, "", "[CLASS:Button; INSTANCE:2]") ;Click Save
Sleep(2000)
-------------------------------------------------------------------------
::20190417
https://stackoverflow.com/questions/39073247/how-to-get-confirm-box-return-value-in-asp-net-c-sharp
https://www.codeproject.com/Questions/1192829/Csharp-ASP-NET-how-to-get-a-confirm-message-box-fr
http://www.blueshop.com.tw/board/FUM20041006161839LRJ/BRD20101213105317KIR.html
https://dotblogs.com.tw/jimmyyu/archive/2009/06/07/8712.aspx
http://shaurong.blogspot.com/2017/06/c-aspnet.html
http://codeverge.com/asp.net.web-forms/confirm-message-box-with-ok-or-cancel-optio/431380
https://www.aspsnippets.com/Articles/Server-Side-Code-Behind-Yes-No-Confirmation-Message-Box-in-ASPNet.aspx
https://forums.asp.net/t/1385869.aspx?Confirm+Message+Box+with+OK+or+Cancel+option+in+C+
-------------------------------------------------------------------------
@ECHO OFF
setlocal enabledelayedexpansion

::取年月日
For /f "tokens=1-3 delims=/ " %%a in ('date /t') do (set datetime=%%a%%b%%c)

::各別取年、月、日
set years=%date:~0,4%
set month=%date:~5,2%
set day=%date:~8,2%

::取時、分、秒
set time=%time:~0,2%%time:~3,2%%time:~6,2%

::檔案及路徑設定1
set file1=SE2000_G1.csv
set path1=D:\Temp\XML
set target1=SE2000_WB-2FFAB-N001_G1_%datetime%_%time%.csv

::檔案及路徑設定2
set file2=SE2000_G2.csv
set path2=D:\Temp\XML
set target2=SE2000_WB-2FFAB-N001_G2_%datetime%_%time%.csv

::備份路徑
set BackupPath=D:\SE2000_DATA

:START
::判斷D:\是否有檔案，若沒有則跳下一個檔案
IF NOT EXIST "D:\%file1%" ( GOTO NEXT )

::備份至backup
copy /Y D:\%file1% %BackupPath%\%target1%

::判斷路徑存不存在，若不存在則建立路徑。
set lookup=0
IF EXIST "%path1%\%years%\%month%\%day%\" (set lookup=1)
IF %lookup% EQU 0 ( mkdir %path1%\%years%\%month%\%day%\)

::判斷檔案存不存在，若存在則copy 至指定路徑。
set cp=0
IF EXIST "D:\%file1%" (set cp=1)
IF %cp% EQU 1 (move /Y D:\%file1%  %path1%\%years%\%month%\%day%\%target1% )

:NEXT
::判斷D:\是否有檔案，若沒有則離開程式
IF NOT EXIST "D:\%file2%" ( GOTO EXIT )

::備份至backup
copy /Y D:\%file2% %BackupPath%\%target2%

::判斷路徑存不存在，若不存在則建立路徑。
set lookup=0
IF EXIST "%path2%\%years%\%month%\%day%\" (set lookup=1)
IF %lookup% EQU 0 ( mkdir %path2%\%years%\%month%\%day%\)

::判斷檔案存不存在，若存在則copy 至指定路徑。
set cp=0
IF EXIST "D:\%file2%" (set cp=1)
IF %cp% EQU 1 (move /Y D:\%file2%  %path2%\%years%\%month%\%day%\%target2% )

:EXIT
-------------------------------------------------------------------------
::[batchfile sample]
::強制顯示為 6 為 06(兩位數)
::Digital complement two digit length
set %2=6
set s=
set a=
set /a a=%2+100
set s=!s! !a:~1!
echo "OUT: "%s%

::Digital complement two digit length
set s=
set a=
set /a a=%2+100
set s=!s! !a:~1!
::echo "OUT: "%s%

::Digital complement two digit length
set s=
set a=
FOR /L %%i in (1,1,%2) DO ( 
set /a a=%%i+100
set s=!s! !a:~1!
)
::echo "OUT: "%s%
-------------------------------------------------------------------------
-------------------------------------------------------------------------
-------------------------------------------------------------------------
