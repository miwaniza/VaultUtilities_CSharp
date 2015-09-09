//Form1.cs


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EPDM.Interop.epdm;
using Microsoft.VisualBasic;

namespace VaultUtilities_CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private IEdmVault5 vault1 = null;

        public void Form1_Load(System.Object sender, System.EventArgs e)
        {
            try
            {
                IEdmVault5 vault1 = new EdmVault5();
                IEdmVault8 vault = (IEdmVault8)vault1;
                EdmViewInfo[] Views = null;

                vault.GetVaultViews(out Views, false);
                VaultsComboBox.Items.Clear();
                foreach (EdmViewInfo View in Views)
                {
                    VaultsComboBox.Items.Add(View.mbsVaultName);
                }
                if (VaultsComboBox.Items.Count > 0)
                {
                    VaultsComboBox.Text = (string)VaultsComboBox.Items[0];
                }
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Button5_Click(System.Object sender, System.EventArgs e)
        {
            //Verify SOLIDWORKS Enterprise PDM version is 5.3 or higher
            try
            {
                IEdmVault7 vault2 = null;
                if (vault1 == null)
                {
                    vault1 = new EdmVault5();
                }
                vault2 = (IEdmVault7)vault1;
                if (!vault1.IsLoggedIn)
                {
                    vault1.LoginAuto(VaultsComboBox.Text, this.Handle.ToInt32());
                }

                vault2.VerifyVersion(5, 3);

                MessageBox.Show("SOLIDWORKS Enterprise PDM version is at least 5.3");

            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button6_Click(System.Object sender, System.EventArgs e)
        {
            //Get licenses
            try
            {
                IEdmVault11 vault2 = null;
                if (vault1 == null)
                {
                    vault1 = new EdmVault5();
                }
                vault2 = (IEdmVault11)vault1;
                if (!vault1.IsLoggedIn)
                {
                    vault1.LoginAuto(VaultsComboBox.Text, this.Handle.ToInt32());
                }

                string msg = null;
                msg = "Installed licenses:" + Constants.vbLf;
                EdmLicense[] lics = null;
                lics = null;
                vault2.GetLicense(out lics);
                int idx = 0;
                idx = Information.LBound(lics);
                while ((idx <= Information.UBound(lics)))
                {
                    msg = msg + "Type=";
                    switch (lics[idx].meType)
                    {
                        case EdmLicenseType.EdmLic_Editor:
                            msg = msg + "Editor";
                            break;
                        case EdmLicenseType.EdmLic_Contributor:
                            msg = msg + "Contributor";
                            break;
                        case EdmLicenseType.EdmLic_Viewer:
                            msg = msg + "Viewer";
                            break;
                        case EdmLicenseType.EdmLic_Processor:
                            msg = msg + "Processor";
                            break;
                        default:
                            msg = msg + Convert.ToString(lics[idx].meType);
                            break;
                    }

                    msg = msg + " Users=" + Convert.ToString(lics[idx].mlUserCount) + Constants.vbLf;
                    idx = idx + 1;
                }

                vault2.MsgBox(this.Handle.ToInt32(), msg);

            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button7_Click(System.Object sender, System.EventArgs e)
        {
            //Add group, My Group
            try
            {
                IEdmVault11 vault2 = null;
                if (vault1 == null)
                {
                    vault1 = new EdmVault5();
                }
                vault2 = (IEdmVault11)vault1;
                if (!vault1.IsLoggedIn)
                {
                    vault1.LoginAuto(VaultsComboBox.Text, this.Handle.ToInt32());
                }

                IEdmUserMgr7 userMgr = default(IEdmUserMgr7);
                userMgr = (IEdmUserMgr7)vault2.CreateUtility(EdmUtility.EdmUtil_UserMgr);

                IEdmUser7 admin = default(IEdmUser7);
                admin = (IEdmUser7)userMgr.GetUser("Admin");

                EdmGroupData2[] groups = new EdmGroupData2[1];
                groups[0].mbAutoAdd = 0;
                groups[0].mbsDescription = "A group created by the API";
                groups[0].mbsName = "My Group";
                groups[0].mlFlags = (int)EdmGroupDataFlags.Edmgdf_GetInterface;
                int[] members = new int[1];
                members[0] = admin.ID;
                groups[0].moMembers = members;
                EdmSysPerm[] perms = new EdmSysPerm[1];
                perms[0] = EdmSysPerm.EdmSysPerm_ModifyToolbox;
                groups[0].moSysPerms = perms;

                userMgr.AddGroups2(ref groups);

                string msg = null;
                msg = "";
                int idx = 0;
                idx = Information.LBound(groups);
                while ((idx <= Information.UBound(groups)))
                {
                    if (groups[idx].mhStatus != 0)
                    {
                        msg = msg + "Error creating group, '" + groups[idx].mbsName + "' - " + vault2.GetErrorMessage(groups[idx].mhStatus) + Constants.vbLf;
                    }
                    else
                    {
                        msg = msg + "Created group, '" + groups[idx].mbsName + "', successfully with ID, " + groups[idx].mlGroupID.ToString() + Constants.vbLf;
                    }
                    idx = idx + 1;
                }

                vault2.MsgBox(this.Handle.ToInt32(), msg);

            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button8_Click(System.Object sender, System.EventArgs e)
        {
            //Remove group, My Group
            try
            {
                IEdmVault7 vault2 = null;
                if (vault1 == null)
                {
                    vault1 = new EdmVault5();
                }
                vault2 = (IEdmVault7)vault1;
                if (!vault1.IsLoggedIn)
                {
                    vault1.LoginAuto(VaultsComboBox.Text, this.Handle.ToInt32());
                }

                IEdmUserMgr7 userMgr = default(IEdmUserMgr7);
                userMgr = (IEdmUserMgr7)vault2.CreateUtility(EdmUtility.EdmUtil_UserMgr);
                IEdmUserGroup6 @group = default(IEdmUserGroup6);
                @group = (IEdmUserGroup6)userMgr.GetUserGroup("My Group");
                if (@group == null)
                    return;

                int[] groups = new int[1];
                groups[0] = @group.ID;
                userMgr.RemoveGroups(groups);

                MessageBox.Show("Group, My Group, removed");

            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button9_Click(System.Object sender, System.EventArgs e)
        {
            //Add user, Temp
            try
            {
                IEdmVault11 vault2 = null;
                if (vault1 == null)
                {
                    vault1 = new EdmVault5();
                }
                vault2 = (IEdmVault11)vault1;
                if (!vault1.IsLoggedIn)
                {
                    vault1.LoginAuto(VaultsComboBox.Text, this.Handle.ToInt32());
                }

                IEdmUserMgr7 UsrMgr = (IEdmUserMgr7)vault2;
                EdmUserData2[] UserData = new EdmUserData2[1];

                UserData[0].mbsCompleteName = "Temp";
                UserData[0].mbsEmail = "Temp";
                UserData[0].mbsInitials = "TJ";
                UserData[0].mbsUserName = "Temp";
                UserData[0].mlFlags = (int)EdmUserDataFlags.Edmudf_GetInterface;
                UserData[0].mlFlags += (int)EdmUserDataFlags.Edmudf_ForceAdd;

                EdmSysPerm[] perms = new EdmSysPerm[3];
                perms[0] = EdmSysPerm.EdmSysPerm_EditUserMgr;
                perms[1] = EdmSysPerm.EdmSysPerm_EditReportQuery;
                perms[2] = EdmSysPerm.EdmSysPerm_MandatoryVersionComments;
                UserData[0].moSysPerms = perms;

                UsrMgr.AddUsers2(UserData);

                string msg = "";
                foreach (EdmUserData2 usr in UserData)
                {
                    if (usr.mhStatus == 0)
                    {
                        msg += "Created user, \"" + usr.mbsUserName + "\", successfully with ID, " + usr.mlUserID.ToString() + Constants.vbCrLf;
                    }
                    else
                    {
                        msg += "Error creating user, \"" + usr.mbsUserName + "\" - " + vault2.GetErrorMessage(usr.mhStatus) + Constants.vbCrLf;
                    }
                }
                MessageBox.Show(msg);


            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button10_Click(System.Object sender, System.EventArgs e)
        {
            //Remove user, Temp
            try
            {
                IEdmVault7 vault2 = null;
                if (vault1 == null)
                {
                    vault1 = new EdmVault5();
                }
                vault2 = (IEdmVault7)vault1;
                if (!vault1.IsLoggedIn)
                {
                    vault1.LoginAuto(VaultsComboBox.Text, this.Handle.ToInt32());
                }

                IEdmUserMgr7 userMgr = default(IEdmUserMgr7);
                userMgr = (IEdmUserMgr7)vault2.CreateUtility(EdmUtility.EdmUtil_UserMgr);
                IEdmUser7 user = default(IEdmUser7);
                user = (IEdmUser7)userMgr.GetUser("Temp");
                if (user == null)
                    return;

                int[] users = new int[1];
                users[0] = user.ID;
                userMgr.RemoveUsers(users);

                MessageBox.Show("User, Temp, removed");

            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button4_Click(System.Object sender, System.EventArgs e)
        {
            //Get user's check-out permission for a file
            try
            {
                IEdmVault7 vault2 = null;
                if (vault1 == null)
                {
                    vault1 = new EdmVault5();
                }
                vault2 = (IEdmVault7)vault1;
                if (!vault1.IsLoggedIn)
                {
                    vault1.LoginAuto(VaultsComboBox.Text, this.Handle.ToInt32());
                }

                EdmStrLst5 pathList = default(EdmStrLst5);
                pathList = vault2.BrowseForFile(this.Handle.ToInt32(), (int)EdmBrowseFlag.EdmBws_ForOpen + (int)EdmBrowseFlag.EdmBws_PermitVaultFiles);
                if (pathList == null)
                    return;

                IEdmFile5 file = default(IEdmFile5);
                IEdmFolder5 srcFolder = null;
                file = vault2.GetFileFromPath(pathList.GetNext(pathList.GetHeadPosition()), out srcFolder);

                if (srcFolder.HasRightsEx((int)EdmRightFlags.EdmRight_Lock, file.ID))
                {
                    Interaction.MsgBox("User can check out this file");
                }
                else
                {
                    Interaction.MsgBox("User does not have check-out permission");
                }

            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button1_Click(System.Object sender, System.EventArgs e)
        {
            //Copy file
            try
            {
                IEdmVault7 vault2 = null;
                if (vault1 == null)
                {
                    vault1 = new EdmVault5();
                }
                vault2 = (IEdmVault7)vault1;
                if (!vault1.IsLoggedIn)
                {
                    vault1.LoginAuto(VaultsComboBox.Text, this.Handle.ToInt32());
                }

                EdmStrLst5 pathList = default(EdmStrLst5);
                pathList = vault2.BrowseForFile(this.Handle.ToInt32(), (int)EdmBrowseFlag.EdmBws_ForOpen + (int)EdmBrowseFlag.EdmBws_PermitVaultFiles);
                if (pathList == null)
                    return;

                IEdmFile5 file = default(IEdmFile5);
                IEdmFolder5 srcFolder = null;
                file = vault2.GetFileFromPath(pathList.GetNext(pathList.GetHeadPosition()), out srcFolder);

                IEdmFolder5 destFolder = default(IEdmFolder5);
                destFolder = vault2.BrowseForFolder(this.Handle.ToInt32(), "Select destination folder:");
                if (destFolder == null)
                    return;

                int fileID = 0;
                fileID = destFolder.CopyFile(file.ID, srcFolder.ID, this.Handle.ToInt32(), "", (int)EdmCopyFlag.EdmCpy_Simple);
                Interaction.MsgBox("Copied file successfully to new file with ID, " + fileID);

            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button2_Click(System.Object sender, System.EventArgs e)
        {
            //Delete file
            try
            {
                IEdmVault7 vault2 = null;
                if (vault1 == null)
                {
                    vault1 = new EdmVault5();
                }
                vault2 = (IEdmVault7)vault1;
                if (!vault1.IsLoggedIn)
                {
                    vault1.LoginAuto(VaultsComboBox.Text, this.Handle.ToInt32());
                }

                EdmStrLst5 pathList = default(EdmStrLst5);
                pathList = vault2.BrowseForFile(this.Handle.ToInt32(), (int)EdmBrowseFlag.EdmBws_ForOpen + (int)EdmBrowseFlag.EdmBws_PermitVaultFiles + (int)EdmBrowseFlag.EdmBws_PermitMultipleSel, "", "", "", "", "Select Files to Delete");
                if (pathList == null)
                    return;

                IEdmPos5 pos = default(IEdmPos5);
                pos = pathList.GetHeadPosition();
                while (!pos.IsNull)
                {
                    IEdmFile5 file = default(IEdmFile5);
                    IEdmFolder5 folder = null;
                    file = vault2.GetFileFromPath(pathList.GetNext(pos), out folder);
                    folder.DeleteFile(this.Handle.ToInt32(), file.ID);
                }

                string strCount = null;
                strCount = pathList.Count.ToString();
                MessageBox.Show("Deleted " + strCount + " file");

            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button3_Click(System.Object sender, System.EventArgs e)
        {
            //Delete folder
            try
            {
                IEdmVault7 vault2 = null;
                if (vault1 == null)
                {
                    vault1 = new EdmVault5();
                }
                vault2 = (IEdmVault7)vault1;
                if (!vault1.IsLoggedIn)
                {
                    vault1.LoginAuto(VaultsComboBox.Text, this.Handle.ToInt32());
                }

                IEdmFolder5 folder = default(IEdmFolder5);
                folder = vault2.BrowseForFolder(this.Handle.ToInt32(), "Select folder to delete:");
                if (folder == null)
                    return;

                IEdmFolder5 parentFolder = default(IEdmFolder5);
                parentFolder = folder.ParentFolder;

                if (parentFolder == null)
                {
                    Interaction.MsgBox("You cannot delete the vault root folder");
                    return;
                }

                parentFolder.DeleteFolder(this.Handle.ToInt32(), folder.ID);

                MessageBox.Show(folder.Name + " deleted");

            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + " " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}