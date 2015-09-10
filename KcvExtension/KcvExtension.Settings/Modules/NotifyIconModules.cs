using AMing.KcvExtension.Core.Generic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using winforms = System.Windows.Forms;
using AMing.KcvExtension.Core.Hub;

namespace AMing.KcvExtension.Settings.Modules
{
    public class NotifyIconModules : ModulesBase
    {
        public static NotifyIconModules Current { get; } = new NotifyIconModules();

        public override string Key { get; set; } = "AMing.KcvExtension.Settings.NotifyIconModules";
#if DEBUG
        const string iconPath = "pack://application:,,,/KcvExtension.Test;Component/img/17.ico";
#else
        const string iconPath = "pack://application:,,,/KanColleViewer;Component/Assets/app.ico";
#endif
        winforms.NotifyIcon _notifyIcon;
        Window mainWindow;
        winforms.ContextMenu contextMenu;
        winforms.MenuItem exitItem;
        bool _notifyInit = false;

        public override void MainWindowFristActivated()
        {
            base.MainWindowFristActivated();
            mainWindow = Application.Current.MainWindow;

            InitNotifyIcon();
            ResetNotifyIconVisible();
            InitPublicModules();

            RadioHub.Current.Register(this, Data.MessageKeys.Windows_State_Changed, x =>
            {
                if (DynamicArgs<WindowState>.Validation(x))
                {
                    _notifyIcon.Text = GetTitle();
                }
            });
        }
        public override void MainWindowExit()
        {
            base.MainWindowExit();
            if (_notifyIcon != null)
            {
                _notifyIcon.Visible = false;
                _notifyIcon.Dispose();
            }
        }

        #region method


        void InitNotifyIcon()
        {
            try
            {
                Uri iconUri = new Uri(iconPath, UriKind.Absolute);
                using (var icon_stream = Application.GetResourceStream(iconUri).Stream)
                {
                    contextMenu = new winforms.ContextMenu();

                    exitItem = new winforms.MenuItem
                    {
                        Text = TextResource.NotifyIcon_ContextMenu_Exit
                    };
                    exitItem.Click += exitItem_Click;

                    contextMenu.MenuItems.Add(exitItem);

                    _notifyIcon = new System.Windows.Forms.NotifyIcon
                    {
                        Text = GetTitle(),
                        Icon = new Icon(icon_stream),
                        ContextMenu = contextMenu
                    };
                    _notifyIcon.DoubleClick += _notifyIcon_DoubleClick;
                }


                _notifyInit = true;
            }
            catch (Exception ex)
            {
            }
        }

        string GetTitle()
        {
            return string.Format("{2}{1}{0}", TextResource.KanColleViewer,
                (Application.Current.MainWindow.WindowState == WindowState.Minimized) ? TextResource.Show : TextResource.Hide,
                TextResource.DoubleClick);
        }

        /// <summary>
        /// 根据配置重新设置NotifyIcon的Visible值
        /// </summary>
        public void ResetNotifyIconVisible()
        {
            if (_notifyIcon == null || !_notifyInit)
            {
                return;
            }
            _notifyIcon.Visible = Data.Settings.SettingsCurrent.Settings.EnableNotifyIcon;
        }

        #region PublicModules


        public Core.Helper.ListenerMemberHelper ListenerMemberHelper { get; private set; }

        void InitPublicModules()
        {
            if (_notifyIcon == null || !_notifyInit)
            {
                return;
            }
            ListenerMemberHelper = new Core.Helper.ListenerMemberHelper(Core.Enums.ListenerMemberType.Function, AddPublicModules);
        }

        void AddPublicModules(Core.Interface.IListenerMember listenerMember)
        {

            var menuItem = new winforms.MenuItem
            {
                Text = listenerMember.Name,
                Tag = listenerMember.OnlyListenerKey
            };
            menuItem.Click += (sender, e) => RadioHub.Current.Send(listenerMember.OnlyListenerKey);

            contextMenu.MenuItems.Add(menuItem);
            //-,-为了将退出项移到最后一个
            contextMenu.MenuItems.Remove(exitItem);
            contextMenu.MenuItems.Add(exitItem);
        }
        #endregion

        #endregion

        #region event

        void exitItem_Click(object sender, EventArgs e)
        {
            RadioHub.Current.Send(Data.MessageKeys.Windows_Close);
        }

        void _notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            RadioHub.Current.Send(Data.MessageKeys.Windows_ShowOrHide_All);
        }
        #endregion
    }
}
