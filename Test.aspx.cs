/*

NeatUpload - an HttpModule and User Controls for uploading large files
Copyright (C) 2005  Dean Brettle

This library is free software; you can redistribute it and/or
modify it under the terms of the GNU Lesser General Public
License as published by the Free Software Foundation; either
version 2.1 of the License, or (at your option) any later version.

This library is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public
License along with this library; if not, write to the Free Software
Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;

namespace Brettle.Web.NeatUpload
{
	public class Test : System.Web.UI.Page
	{	
		protected HtmlForm form;
		protected TestControl testControl;
		protected HtmlGenericControl bodyPre;
		
		protected override void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);
		}
		
		private void InitializeComponent()
		{
			this.PreRender += new System.EventHandler(this.Page_PreRender);
		}
		
		private void Page_PreRender(object sender, EventArgs e)
		{
			if (this.IsPostBack)
			{
				if (testControl.inputFile.TmpFile != null)
				{
					/* 
						In a real app, you'd do something like:
							inputFile.TmpFile.MoveTo(inputFile.FileName);
					*/
					bodyPre.InnerText = "Name: " + testControl.inputFile.FileName + "\n";
					bodyPre.InnerText += "Size: " + testControl.inputFile.TmpFile.Length + "\n";
					bodyPre.InnerText += "Content type: " + testControl.inputFile.ContentType + "\n"; 
				}
			}
		}

	}
}
