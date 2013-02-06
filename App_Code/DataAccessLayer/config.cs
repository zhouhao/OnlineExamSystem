using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// config 的摘要说明
/// </summary>
public class config
{
    public SqlConnection myConnection;
    public DataSet ds;
    private void Page_Load(object sender, System.EventArgs e)
    {
        // 在此处放置用户代码以初始化页面
    }
    public void open()
    {
        myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        myConnection.Open();
    }
    public void Close()
    {
        if (ds != null) // 清除DataSet对象
        {
            ds.Clear();
        }
        if (myConnection != null)
        {
            myConnection.Close(); // 关闭数据库
        }
    }
    public string rep(string cc)
    {
        if (cc == null)
            cc = "";
        cc = cc.Trim();
        if (cc == "")
            cc = " ";
        else
            cc = cc.Replace("'", "''");
        cc = "'" + cc + "'";
        return cc;
    }
   
    /// <summary>
    /// 获得某个字符串在另个字符串第一次出现时前面所有字符
    /// </summary>
    /// <param name="strOriginal">要处理的字符</param>
    /// <param name="strSymbol">符号</param>
    /// <returns>返回值</returns>
    public string GetFirstStr(string strOriginal, string strSymbol)
    {
        int strPlace = strOriginal.IndexOf(strSymbol);
        if (strPlace != -1)
            strOriginal = strOriginal.Substring(0, strPlace);
        return strOriginal;
    }
    /// <summary>
    ///  获得两个字符之间最后一次出现时的所有字符
    /// </summary>
    /// <param name="strOriginal">要处理的字符</param>
    /// <param name="strFirst">最前哪个字符</param>
    /// <param name="strLast">最后哪个字符</param>
    /// <returns>返回值</returns>
    public string GetTwoMiddleLastStr(string strOriginal, string strFirst, string strLast)
    {
        strOriginal = GetLastStr(strOriginal, strFirst);
        strOriginal = GetFirstStr(strOriginal, strLast);
        return strOriginal;
    }
    /// <summary>
    /// 获得某个字符串在另个字符串最后一次出现时后面所有字符
    /// </summary>
    /// <param name="strOriginal">要处理的字符</param>
    /// <param name="strSymbol">符号</param>
    /// <returns>返回值</returns>
    public string GetLastStr(string strOriginal, string strSymbol)
    {
        int strPlace = strOriginal.LastIndexOf(strSymbol) + strSymbol.Length;
        strOriginal = strOriginal.Substring(strPlace);
        return strOriginal;
    }
    /// <summary>
    /// 获得两个字符之间第一次出现时前面所有字符
    /// </summary>
    /// <param name="strOriginal">要处理的字符</param>
    /// <param name="strFirst">最前哪个字符</param>
    /// <param name="strLast">最后哪个字符</param>
    /// <returns>返回值</returns>
    public string GetTwoMiddleFirstStr(string strOriginal, string strFirst, string strLast)
    {
        strOriginal = GetFirstStr(strOriginal, strLast);
        strOriginal = GetLastStr(strOriginal, strFirst);
        return strOriginal;
    }
		
}
