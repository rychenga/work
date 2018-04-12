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
