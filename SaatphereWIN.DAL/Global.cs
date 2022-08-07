using System.Collections;

namespace SaatphereWIN.DAL
{
    public class Global
    {
        public static string FrRowId = string.Empty;
        public static string CheckLogin = string.Empty;
        public static string Checkvalidate = string.Empty;
        public static string MessageforFav = string.Empty;
        public static string LoginMessage = string.Empty;
        public static string Customerviewbylogin = string.Empty;
        public static string CustRowId = string.Empty;
        public static string CustomerGender = string.Empty;
        public static string Frusername = string.Empty;
        public static string LoginUser = string.Empty;
        public static string LoginMessageforDetails = string.Empty;
        public static string Unameinsert = string.Empty;
        public static string 
            = string.Empty;
        public static string Password2 = string.Empty;
        public static string UserIdCreated = string.Empty;


        //Notification XMLS
        public static string UpdateAgeXml = "UpdateXML.xml";

        //We dont know the users who will create the complaints through the online portal and hence their user id is 001 for our reference.
        //It means if the user id is 001 then this user is Anonymous who has created the complaint
        public static int WebAnonymousUser = 001;


        public Hashtable GetOfficeLocations()
        {
             Hashtable ht = new Hashtable();
         
             ht.Add("mumbaioffice", "Mumbai Office");
             ht.Add("jaipuroffice", "Jaipur Office");
             ht.Add("andherioffice", "Andheri Office");
             ht.Add("puneoffice", "Pune Office");
             ht.Add("indoreoffice", "Indore Office");
             ht.Add("swargateoffice", "Swargate Office");

             return ht;
        }

        public static string TemplateProfilesWithoutAddress = "<table border='0' cellpadding='0' cellspacing='0'>" +
                                     "                                   <tr>" +
                                      "                                      <td align='center' height='150' rowspan='12' valign='middle' width='150'>" +
                                       "                                        {image}</td>" +
                                        "                                    <td align='center' height='150' rowspan='12' valign='middle' class='style1'>" +
                                         "                                       &nbsp;</td>" +
                                          "                                  <td height='25'>" +
                                           "                                     &nbsp;</td>" +
                                           "                                 <td colspan='2' height='50' rowspan='2' width='275' style='font-family: tahoma'>" +
                                            "                                    <b><font size='3'>" +
                                             "                                   {name}" +
                                              "                                  <br />" +
                                               "                                 <br />" +
                                                "                                </font></b><font color='#808080' face='Verdana' style='font-size: 8pt'>" +
                                                 "                               {educationstatus}" +
                                                  "                              &nbsp;|" +
                                                   "                             {occupation}" +
                                                    "                            <br />" +
                                                     "                           </font><font face='Verdana'><span style='font-size: 8pt'>" +
                                                      "                          {religion}" +
                                                       "                         &nbsp;|" +
                                                        "                        {country}" +
                                                         "                       </span></font>" +
                                                          "                  </td>" +
                                                           "             </tr>" +
                                                            "            <tr>" +
                                                             "               <td height='25'>" +
                                                              "                  &nbsp;</td>" +
                                                               "         </tr>" +
                                                                "        <tr>" +
                                                                 "           <td>" +
                                                                  "          </td>" +
                                                                   "         <td colspan='2' width='275'>" +
                                                                            "</td>" +
                                               "                         </tr>" +
                                                "                        <tr>" +
                                                 "                           <td height='25'>" +
                                                  "                              &nbsp;</td>" +
                                                   "                         <td align='right' height='25' nowrap " +
                                                    "                            style='font-family: tahoma; font-size: 9pt'>" +
                                                     "                           <font face='Verdana' style='font-size: 8pt'>Profile Id:&nbsp;&nbsp; </font>" +
                                                      "                      </td>" +
                                                       "                     <td height='25' width='210' class='style9'>" +
                                                        "                        <font face='Verdana' style='font-size: 8pt'>{profileid}</font>" +
                                                         "                   </td>" +
                                                          "              </tr>" +
                                                                        "<tr> " +
                                                    "                        <td height='25'>" +
                                                     "                           &nbsp;</td>" +
                                                      "                      <td align='right' class='style9' height='25' " +
                                                       "                         style='font-family: tahoma; font-size: 9pt'>" +
                                                        "                        <font face='Verdana' style='font-size: 8pt'>Contact Person:&nbsp;&nbsp; </font>" +
                                                         "                   </td>" +
                                                          "                  <td height='25' width='210' style='font-family: tahoma; font-size: 9pt'>" +
                                                           "                     <font face='Verdana' style='font-size: 8pt'>{contactpersonname}</font>" +
                                                            "                </td>" +
                                                             "           </tr>" +
                                                           "             <tr>" +
                                                    "                        <td height='25'>" +
                                                     "                           &nbsp;</td>" +
                                                      "                      <td align='right' class='style9' height='25' " +
                                                       "                         style='font-family: tahoma; font-size: 9pt'>" +
                                                        "                        <font face='Verdana' style='font-size: 8pt'>Caste:&nbsp;&nbsp; </font>" +
                                                         "                   </td>" +
                                                          "                  <td height='25' width='210' style='font-family: tahoma; font-size: 9pt'>" +
                                                           "                     <font face='Verdana' style='font-size: 8pt'>{caste}</font>" +
                                                            "                </td>" +
                                                             "           </tr>" +
                                                              "          <tr>" +
                                                               "             <td height='25'>" +
                                                                "                &nbsp;</td>" +
                                                                 "           <td align='right' class='style9' height='25' " +
                                                                  "              style='font-family: tahoma; font-size: 9pt'>" +
                                                                   "             <font face='Verdana' style='font-size: 8pt'>City:&nbsp;&nbsp;&nbsp; </font>" +
                                                                    "        </td>" +
                                                                     "       <td height='25' width='210' style='font-family: tahoma; font-size: 9pt'>" +
                                                                      "          <font face='Verdana' style='font-size: 8pt'>{city}</font>" +
                                                                       "     </td>" +
                                                                        "</tr>" +
                                                                        "<tr> " +
                                                               "             <td height='25'>" +
                                                                "                &nbsp;</td>" +
                                                                 "           <td align='right' class='style9' height='25' " +
                                                                  "              style='font-family: tahoma; font-size: 9pt'>" +
                                                                   "             <font face='Verdana' style='font-size: 8pt'>Address:&nbsp;&nbsp;&nbsp; </font>" +
                                                                    "        </td>" +
                                                                     "       <td height='25' width='210' style='font-family: tahoma; font-size: 9pt'>" +
                                                                      "          <font face='Verdana' style='font-size: 8pt'>{address}</font>" +
                                                                       "     </td>" +
                                                                        "</tr>" +
                                                                            "<tr> " +
                                                               "             <td height='25'>" +
                                                                "                &nbsp;</td>" +
                                                                 "           <td align='right' class='style9' height='25' " +
                                                                  "              style='font-family: tahoma; font-size: 9pt'>" +
                                                                   "             <font face='Verdana' style='font-size: 8pt'>Contact:&nbsp;&nbsp;&nbsp; </font>" +
                                                                    "        </td>" +
                                                                     "       <td height='25' width='210' style='font-family: tahoma; font-size: 9pt'>" +
                                                                      "          <font face='Verdana' style='font-size: 8pt'>{contact}</font>" +
                                                                       "     </td>" +
                                                                        "</tr>" +
                                                                        "<tr> " +
                                                               "             <td height='25'>" +
                                                                "                &nbsp;</td>" +
                                                                 "           <td align='right' class='style9' height='25' " +
                                                                  "              style='font-family: tahoma; font-size: 9pt'>" +
                                                                   "             <font face='Verdana' style='font-size: 8pt'>Email Address 1:&nbsp;&nbsp;&nbsp; </font>" +
                                                                    "        </td>" +
                                                                     "       <td height='25' width='210' style='font-family: tahoma; font-size: 9pt'>" +
                                                                      "          <font face='Verdana' style='font-size: 8pt'>{emailaddress1}</font>" +
                                                                       "     </td>" +
                                                                            "</tr>" +
                                                                           "<tr> " +
                                                               "             <td height='25'>" +
                                                                "                &nbsp;</td>" +
                                                                 "           <td align='right' class='style9' height='25' " +
                                                                  "              style='font-family: tahoma; font-size: 9pt'>" +
                                                                   "             <font face='Verdana' style='font-size: 8pt'>Email Address 2:&nbsp;&nbsp;&nbsp; </font>" +
                                                                    "        </td>" +
                                                                     "       <td height='25' width='210' style='font-family: tahoma; font-size: 9pt'>" +
                                                                      "          <font face='Verdana' style='font-size: 8pt'>{emailaddress2}</font>" +
                                                                       "     </td>" +
                                                                        "</tr>" +
                                                                        "<tr> " +
                                                               "             <td height='25'>" +
                                                                "                &nbsp;</td>" +
                                                                 "           <td align='right' class='style9' height='25' " +
                                                                  "              style='font-family: tahoma; font-size: 9pt'>" +
                                                                   "             <font face='Verdana' style='font-size: 8pt'>Email Address 3:&nbsp;&nbsp;&nbsp; </font>" +
                                                                    "        </td>" +
                                                                     "       <td height='25' width='210' style='font-family: tahoma; font-size: 9pt'>" +
                                                                      "          <font face='Verdana' style='font-size: 8pt'>{emailaddress3}</font>" +
                                                                       "     </td>" +
                                                                        "</tr>" +
                                 "                                       <tr>" +
                                  "                                          <td>" +
                                   "                                             &nbsp;</td>" +
                                    "                                        <td class='style1'>" +
                                     "                                           &nbsp;</td>" +
                                      "                                      <td>" +
                                       "                                         &nbsp;</td>" +
                                        "                                    <td style='font-family: tahoma; font-size: 9pt'>" +
                                         "                                       &nbsp;</td>" +
                                          "                                  <td align='left' style='font-family: tahoma; font-size: 9pt'>" +
                                           "                                     &nbsp;</td>" +
                                            "                            </tr>" +
                                             "                           <tr>" +
                                              "                              <td>" +
                                               "                             </td>" +
                                                "                            <td class='style1'>" +
                                                 "                               &nbsp;</td>" +
                                                  "                          <td>" +
                                                   "                         </td>" +
                                                    "                        <td style='font-family: tahoma; font-size: 9pt'>" +
                                                     "                       </td>" +
                                                      "                      <td align='left' style='font-family: tahoma; font-size: 9pt'>" +
                                                       "                         <font face='Verdana' style='font-size: 8.25pt'>" +
                                                        "                        {viewmoredetails}" +
                                                         "                       </font>" +
                                                          "                  </td>" +
                                                           "             </tr>" +
                                                            "            <tr>" +
                                                             "               <td colspan='5' height='25' width='435'>" +
                                                              "                  <hr color='#C0C0C0' size='1' style='width: 98%' />" +
                                                               "             </td>" +
                                                                "        </tr>" +
                                                                 "   </table>";


        public static string MumbaiBorivaliOfficeAddress = "<span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#4BADD1'>MUMBAI BORIVALI :&nbsp;</span><span style='font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;" +
                                                   "color:#8E8E8E'>Saat&nbsp;Phere, 55,&nbsp;Yashwant&nbsp;Shopping Centre, Carter Road 7,&nbsp;Borivali&nbsp;(East), Mumbai.</span></b><o:p></o:p></p>" +
                                                   "<p class='MsoNormal'>" +
                                                    "<b><span style = 'font-size:" +
                                                    "9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#8E8E8E'>Phone:&nbsp;&nbsp;</span><span style='font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#201BAB'>022-28645498 /&nbsp;&nbsp;8655228211 / 8655422601 / 8655228311 / &nbsp;8655228511 / 8655228611&nbsp;</span></b><span style='font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;" +
                                                    "color:#201BAB'>&nbsp;&nbsp; &nbsp;</span>';";

        public static string MumbaiAndheriOfficeAddress = "<span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#4BADD1'>MUMBAI&nbsp;ANDHERI :&nbsp;</span><span style='font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;" +
"color:#8E8E8E'>Saat&nbsp;Phere, B/2,&nbsp;Savitri&nbsp;Sadan, Behind Jain Sweets, Old&nbsp;Nagardas&nbsp;Road,&nbsp;Andheri&nbsp;(East), Mumbai.</span></b><o:p></o:p></p>"+
        "<b><span style = 'font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:"+
"Calibri;mso-fareast-theme-font:minor-latin;color:#8E8E8E;mso-ansi-language:"+
"EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA'>Phone:&nbsp;</span><span style='font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:"+
"Calibri;mso-fareast-theme-font:minor-latin;color:#201BAB;mso-ansi-language:"+
"EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA'>022-28228812 / 9029690824 / 9029371134 / 9699266566 / 9029690824 / 8655041007</span>";


        public static string PuneOfficeAddress = "<span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#4BADD1'>PUNE :&nbsp;</span><span style='font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;"+
"color:#8E8E8E'>Saat&nbsp;Phere&nbsp;, Plot no. 1086, &nbsp;Lenyadri&nbsp;Bunglow&nbsp;,&nbsp;Sathe&nbsp;Colony ,Opp&nbsp;Nitu&nbsp;Mandake&nbsp;Hall,&nbsp;Shukravaar&nbsp;Peth,Tilak&nbsp;Road, Near&nbsp;Swargate,Pune.</span></b><o:p></o:p></p>"+
        "<b><span style = 'font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:"+
"Calibri;mso-fareast-theme-font:minor-latin;color:#8E8E8E;mso-ansi-language:"+
"EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA'>Phone:&nbsp;&nbsp;</span><span style='font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:"+
"Calibri;mso-fareast-theme-font:minor-latin;color:#201BAB;mso-ansi-language:"+
"EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA'>020-24449504 / 8446933184 &nbsp;/ 8087173016</span>";

        public static string JaipurOfficeAddress = "<span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#4BADD1'>Jaipur :&nbsp;</span><span style='font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;" +
"color:#8E8E8E'>Saat&nbsp;Phere&nbsp;, First Floor , Nanak Plaza, Raja Park , Jaipur.</span></b></p>"+
        "<b><span style = 'font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:"+
"Calibri;mso-fareast-theme-font:minor-latin;color:#8E8E8E;mso-ansi-language:"+
"EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA'>Phone:&nbsp;&nbsp;</span><span style='font-size:9.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:"+
"Calibri;mso-fareast-theme-font:minor-latin;color:#201BAB;mso-ansi-language:"+
"EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA'>0141-2620197 / 4020566/ 9214002426 / 9214329468</span>";




    }
}
