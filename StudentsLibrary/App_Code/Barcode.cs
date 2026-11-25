
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

/// <summary>
/// Summary description for Barcode
/// </summary>
public class Barcode
{
	public Barcode()
	{
		//
		// TODO: Add constructor logic here
		//
    }
    public  byte[] Code39(string code, int barSize, bool showCodeString, string title)
    {

         WSBarCode.Barcodes.Code39 c39 = new WSBarCode.Barcodes.Code39();

        // Create stream....
        MemoryStream ms = new MemoryStream();
        c39.FontFamilyName = ConfigurationSettings.AppSettings["BarCodeFontFamily"];
        c39.FontFileName = ConfigurationSettings.AppSettings["BarCodeFontFile"];
        c39.FontSize = barSize;
        c39.ShowCodeString = showCodeString;
        if (title + "" != "")
            c39.Title = title;
        Bitmap objBitmap = c39.GenerateBarcode(code);
        objBitmap.Save(ms, ImageFormat.Png);

        //return bytes....
        return ms.GetBuffer();
    }
}
