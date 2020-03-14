﻿
namespace HuiruiSoft.Win32
{
     /// <summary>Windows message codes WM_</summary>
     public partial class WindowsMessages
     {
          public const int WM_NULL                   = 0x0000;
          
          /// <summary>应用程序创建一个窗口</summary>
          public const int WM_CREATE                 = 0x0001;
          
          /// <summary>一个窗口被销毁</summary>
          public const int WM_DESTROY                = 0x0002;
          
          /// <summary>移动一个窗口</summary>
          public const int WM_MOVE                   = 0x0003;
          
          /// <summary>改变一个窗口的大小</summary>
          public const int WM_SIZE                   = 0x0005;
          
          /// <summary>一个窗口被激活或失去激活状态；</summary>
          public const int WM_ACTIVATE               = 0x0006;
          
          /// <summary>设置获取焦点</summary>
          public const int WM_SETFOCUS               = 0x0007;
          
          /// <summary>失去焦点</summary>
          public const int WM_KILLFOCUS              = 0x0008;
          
          /// <summary>改变enable状态</summary>
          public const int WM_ENABLE                 = 0x000A;
          
          /// <summary>设置窗口是否能重画</summary>
          public const int WM_SETREDRAW              = 0x000B;
          
          /// <summary>应用程序发送此消息来设置一个窗口的文本</summary>
          public const int WM_SETTEXT                = 0x000C;
          
          /// <summary>应用程序发送此消息来复制对应窗口的文本到缓冲区</summary>
          public const int WM_GETTEXT                = 0x000D;
          
          /// <summary>得到与一个窗口有关的文本的长度（不包含空字符）</summary>
          public const int WM_GETTEXTLENGTH          = 0x000E;
          
          /// <summary>要求一个窗口重画自己</summary>
          public const int WM_PAINT                  = 0x000F;
          
          /// <summary>当一个窗口或应用程序要关闭时发送一个信号</summary>
          public const int WM_CLOSE                  = 0x0010;

          /// <summary>当用户选择结束对话框或程序自己调用ExitWindows函数</summary>
          public const int WM_QUERYENDSESSION        = 0x0011;

          /// <summary>用来结束程序运行或当程序调用postquitmessage函数 </summary>
          public const int WM_QUIT                   = 0x0012;

          /// <summary>当用户窗口恢复以前的大小位置时，把此消息发送给某个图标</summary>
          public const int WM_QUERYOPEN              = 0x0013;

          /// <summary>当窗口背景必须被擦除时（例在窗口改变大小时）</summary>
          public const int WM_ERASEBKGND             = 0x0014;

          /// <summary>当系统颜色改变时，发送此消息给所有顶级窗口</summary>
          public const int WM_SYSCOLORCHANGE         = 0x0015;

          /// <summary>当系统进程发出WM_QUERYENDSESSION消息后，此消息发送给应用程序，通知它对话是否结束</summary>
          public const int WM_ENDSESSION             = 0x0016;

          public const int WM_SYSTEMERROR            = 0x0017;

          /// <summary>当隐藏或显示窗口时发送此消息给这个窗口</summary>
          public const int WM_SHOWWINDOW             = 0x0018;

          public const int WM_CTLCOLOR               = 0x0019;
          public const int WM_WININICHANGE           = 0x001A;
          public const int WM_SETTINGCHANGE          = WM_WININICHANGE;
          public const int WM_DEVMODECHANGE          = 0x001B;

          /// <summary>发此消息给应用程序哪个窗口是激活的，哪个是非激活的。</summary>
          public const int WM_ACTIVATEAPP            = 0x001C;

          /// <summary>当系统的字体资源库变化时发送此消息给所有顶级窗口。</summary>
          public const int WM_FONTCHANGE             = 0x001D;

          /// <summary>当系统的时间变化时发送此消息给所有顶级窗口。</summary>
          public const int WM_TIMECHANGE             = 0x001E;

          /// <summary>发送此消息来取消某种正在进行的摸态（操作）。</summary>
          public const int WM_CANCELMODE             = 0x001F;

          /// <summary>如果鼠标引起光标在某个窗口中移动且鼠标输入没有被捕获时，就发消息给某个窗口。</summary>
          public const int WM_SETCURSOR              = 0x0020;

          /// <summary>当光标在某个非激活的窗口中而用户正按着鼠标的某个键发送此消息给当前窗口。</summary>
          public const int WM_MOUSEACTIVATE          = 0x0021;

          /// <summary>发送此消息给MDI子窗口当用户点击此窗口的标题栏，或当窗口被激活，移动，改变大小。</summary>
          public const int WM_CHILDACTIVATE          = 0x0022;

          /// <summary>此消息由基于计算机的训练程序发送，通过WH_JOURNALPALYBACK的hook程序分离出用户输入消息。</summary>
          public const int WM_QUEUESYNC              = 0x0023;

          /// <summary>此消息发送给窗口当它将要改变大小或位置</summary>
          public const int WM_GETMINMAXINFO          = 0x0024;

          /// <summary>发送给最小化窗口当它图标将要被重画。</summary>
          public const int WM_PAINTICON              = 0x0026;

          /// <summary>此消息发送给某个最小化窗口，仅当它在画图标前它的背景必须被重画。</summary>
          public const int WM_ICONERASEBKGND         = 0x0027;

          /// <summary>发送此消息给一个对话框程序去更改焦点位置。</summary>
          public const int WM_NEXTDLGCTL             = 0x0028;

          /// <summary>每当打印管理列队增加或减少一条作业时发出此消息。</summary>
          public const int WM_SPOOLERSTATUS          = 0x002A;

          /// <summary>当button，combobox，listbox，menu的可视外观改变时发送此消息给这些空件的所有者。</summary>
          public const int WM_DRAWITEM               = 0x002B;

          /// <summary>当button, combo box, list box, list view control, or menu item 被创建时发送此消息给控件的所有者</summary>
          public const int WM_MEASUREITEM            = 0x002C;

          /// <summary>当the list box 或 combo box 被销毁 或 当 某些项被删除通过LB_DELETESTRING, LB_RESETCONTENT, CB_DELETESTRING, or CB_RESETCONTENT 消息。</summary>
          public const int WM_DELETEITEM             = 0x002D;

          /// <summary>此消息有一个LBS_WANTKEYBOARDINPUT风格的发出给它的所有者来响应WM_KEYDOWN消息。</summary>
          public const int WM_VKEYTOITEM             = 0x002E;

          /// <summary>此消息由一个LBS_WANTKEYBOARDINPUT风格的列表框发送给他的所有者来响应WM_CHAR消息。</summary>
          public const int WM_CHARTOITEM             = 0x002F;

          /// <summary>当绘制文本时程序发送此消息得到控件要用的颜色。</summary>
          public const int WM_SETFONT                = 0x0030;

          /// <summary>应用程序发送此消息得到当前控件绘制文本的字体。</summary>
          public const int WM_GETFONT                = 0x0031;

          /// <summary>应用程序发送此消息让一个窗口与一个热键相关连。</summary>
          public const int WM_SETHOTKEY              = 0x0032;

          /// <summary>应用程序发送此消息来判断热键与某个窗口是否有关联。</summary>
          public const int WM_GETHOTKEY              = 0x0033;

          /// <summary>此消息发送给最小化窗口，当此窗口将要被拖放而它的类中没有定义图标，应用程序能返回一个图标或光标的句柄，当用户拖放图标时系统显示这个图标或光标。</summary>
          public const int WM_QUERYDRAGICON          = 0x0037;

          /// <summary>发送此消息来判定combobox或listbox新增加的项的相对位置。</summary>
          public const int WM_COMPAREITEM            = 0x0039;

          public const int WM_GETOBJECT              = 0x003D;

          /// <summary>显示内存已经很少了。</summary>
          public const int WM_COMPACTING             = 0x0041;

          public const int WM_COMMNOTIFY             = 0x0044;

          /// <summary>发送此消息给那个窗口的大小和位置将要被改变时，来调用setwindowpos函数或其它窗口管理函数。</summary>
          public const int WM_WINDOWPOSCHANGING      = 0x0046;

          /// <summary>发送此消息给那个窗口的大小和位置已经被改变时，来调用setwindowpos函数或其它窗口管理函数。</summary>
          public const int WM_WINDOWPOSCHANGED       = 0x0047;

          /// <summary>（适用于16位的windows）当系统将要进入暂停状态时发送此消息。</summary>
          public const int WM_POWER                  = 0x0048;

          /// <summary>当一个应用程序传递数据给另一个应用程序时发送此消息。</summary>
          public const int WM_COPYDATA               = 0x004A;

          /// <summary>当某个用户取消程序日志激活状态，提交此消息给程序。</summary>
          public const int WM_CANCELJOURNAL          = 0x004B;

          /// <summary>当某个控件的某个事件已经发生或这个控件需要得到一些信息时，发送此消息给它的父窗口。</summary>
          public const int WM_NOTIFY                 = 0x004E;

          /// <summary>当用户选择某种输入语言，或输入语言的热键改变。</summary>
          public const int WM_INPUTLANGCHANGEREQUEST = 0x0050;

          /// <summary>当平台现场已经被改变后发送此消息给受影响的最顶级窗口。</summary>
          public const int WM_INPUTLANGCHANGE        = 0x0051;

          /// <summary>当程序已经初始化windows帮助例程时发送此消息给应用程序。</summary>
          public const int WM_TCARD                  = 0x0052;

          /// <summary>此消息显示用户按下了F1，如果某个菜单是激活的，就发送此消息个此窗口关联的菜单，否则就发送给有焦点的窗口，如果当前都没有焦点，就把此消息发送给当前激活的窗口。</summary>
          public const int WM_HELP                   = 0x0053;

          /// <summary>当用户已经登入或退出后发送此消息给所有的窗口，当用户登入或退出时系统更新用户的具体设置信息，在用户更新设置时系统马上发送此消息。</summary>
          public const int WM_USERCHANGED            = 0x0054;

          /// <summary>公用控件，自定义控件和他们的父窗口通过此消息来判断控件是使用ANSI还是UNICODE结构在WM_NOTIFY消息，使用此控件能使某个控件与它的父控件之间进行相互通信。</summary>
          public const int WM_NOTIFYFORMAT           = 0x0055;

          /// <summary>当用户某个窗口中点击了一下右键就发送此消息给这个窗口。</summary>
          public const int WM_CONTEXTMENU            = 0x007B;

          /// <summary>当调用SETWINDOWLONG函数将要改变一个或多个窗口的风格时发送此消息给那个窗口。</summary>
          public const int WM_STYLECHANGING          = 0x007C;

          /// <summary>当调用SETWINDOWLONG函数一个或多个窗口的风格后发送此消息给那个窗口。</summary>
          public const int WM_STYLECHANGED           = 0x007D;

          /// <summary>当显示器的分辨率改变后发送此消息给所有的窗口。</summary>
          public const int WM_DISPLAYCHANGE          = 0x007E;

          /// <summary>此消息发送给某个窗口来返回与某个窗口有关连的大图标或小图标的句柄。</summary>
          public const int WM_GETICON                = 0x007F;

          /// <summary>程序发送此消息让一个新的大图标或小图标与某个窗口关联。</summary>
          public const int WM_SETICON                = 0x0080;

          /// <summary>当某个窗口第一次被创建时，此消息在WM_CREATE消息发送前发送。</summary>
          public const int WM_NCCREATE               = 0x0081;

          /// <summary>此消息通知某个窗口，非客户区正在销毁。</summary>
          public const int WM_NCDESTROY              = 0x0082;

          /// <summary>当某个窗口的客户区域必须被核算时发送此消息。</summary>
          public const int WM_NCCALCSIZE             = 0x0083;

          /// <summary>WM_NCHITTEST讯息是一个很特殊的讯息。它是用来决定目前滑鼠所在位置属性的讯息，因此我们可以利用此特性，当滑鼠移至指定的位置时，传回 HTCAPTION，使得系统以为滑鼠目前位於标题棒，如此你就可以移动视窗了。</summary>
          public const int WM_NCHITTEST              = 0x0084;

          /// <summary>程序发送此消息给某个窗口当它（窗口）的框架必须被绘制时。</summary>
          public const int WM_NCPAINT                = 0x0085;

          /// <summary>此消息发送给某个窗口仅当它的非客户区需要被改变来显示是激活还是非激活状态。</summary>
          public const int WM_NCACTIVATE             = 0x0086;

          /// <summary>发送此消息给某个与对话框程序关联的控件，widdows控制方位键和TAB键使输入进入此控件通过响应WM_GETDLGCODE消息，应用程序可以把他当成一个特殊的输入控件并能处理它。</summary>
          public const int WM_GETDLGCODE             = 0x0087;

          public const int WM_SYNCPAINT              = 0x0088;
          
          /// <summary>当光标在一个窗口的非客户区内移动时发送此消息给这个窗口,非客户区为窗体的标题栏及窗的边框体。</summary>
          public const int WM_NCMOUSEMOVE            = 0x00A0;

          /// <summary>当光标在一个窗口的非客户区同时按下鼠标左键时提交此消息。</summary>
          public const int WM_NCLBUTTONDOWN          = 0x00A1;

          /// <summary>当用户释放鼠标左键同时光标某个窗口在非客户区十发送此消息。</summary>
          public const int WM_NCLBUTTONUP            = 0x00A2;

          /// <summary>当用户双击鼠标左键同时光标某个窗口在非客户区十发送此消息。</summary>
          public const int WM_NCLBUTTONDBLCLK        = 0x00A3;

          /// <summary>当用户按下鼠标右键同时光标又在窗口的非客户区时发送此消息。</summary>
          public const int WM_NCRBUTTONDOWN          = 0x00A4;

          /// <summary>当用户释放鼠标右键同时光标又在窗口的非客户区时发送此消息。</summary>
          public const int WM_NCRBUTTONUP            = 0x00A5;

          /// <summary>当用户双击鼠标右键同时光标某个窗口在非客户区十发送此消息。</summary>
          public const int WM_NCRBUTTONDBLCLK        = 0x00A6;

          /// <summary>当用户按下鼠标中键同时光标又在窗口的非客户区时发送此消息。</summary>
          public const int WM_NCMBUTTONDOWN          = 0x00A7;

          /// <summary>当用户释放鼠标中键同时光标又在窗口的非客户区时发送此消息。</summary>
          public const int WM_NCMBUTTONUP            = 0x00A8;

          /// <summary>当用户双击鼠标中键同时光标又在窗口的非客户区时发送此消息。</summary>
          public const int WM_NCMBUTTONDBLCLK        = 0x00A9;

          public const int WM_MINNCCLICK             = WM_NCLBUTTONDOWN;
          public const int WM_MAXNCCLICK             = WM_NCMBUTTONDBLCLK;

          public const int WM_NCXBUTTONDOWN          = 0x00AB;
          public const int WM_NCXBUTTONUP            = 0x00AC;
          public const int WM_NCXBUTTONDBLCLK        = 0x00AD;

          public const int WM_NCUAHDRAWCAPTION       = 0x00AE;

          public const int WM_NCUAHDRAWFRAME         = 0x00AF;


          public const int WM_INPUT_DEVICE_CHANGE    = 0x00FE;

          public const int WM_INPUT                  = 0x00FF;

          public const int WM_KEYFIRST               = 0x0100;

          /// <summary>按下一个键</summary>
          public const int WM_KEYDOWN                = 0x0100;

          /// <summary>释放一个键</summary>
          public const int WM_KEYUP                  = 0x0101;

          /// <summary>按下某键，并已发出WM_KEYDOWN，WM_KEYUP消息。</summary>
          public const int WM_CHAR                   = 0x0102;

          /// <summary>当用translatemessage函数翻译WM_KEYUP消息时发送此消息给拥有焦点的窗口。</summary>
          public const int WM_DEADCHAR               = 0x0103;

          /// <summary>当用户按住ALT键同时按下其它键时提交此消息给拥有焦点的窗口。</summary>
          public const int WM_SYSKEYDOWN             = 0x0104;

          /// <summary>当用户释放一个键同时ALT键还按着时提交此消息给拥有焦点的窗口。</summary>
          public const int WM_SYSKEYUP               = 0x0105;

          /// <summary>当WM_SYSKEYDOWN消息被TRANSLATEMESSAGE函数翻译后提交此消息给拥有焦点的窗口。</summary>
          public const int WM_SYSCHAR                = 0x0106;

          /// <summary>当WM_SYSKEYDOWN消息被TRANSLATEMESSAGE函数翻译后发送此消息给拥有焦点的窗口。</summary>
          public const int WM_SYSDEADCHAR            = 0x0107;
          public const int WM_KEYLAST                = 0x0108;
          public const int WM_UNICHAR                = 0x0109;
          public const int WM_KEYLAST_PRE501         = 0x0108;
          public const int WM_KEYLAST_NT501          = 0x0109;
          public const int WM_IME_STARTCOMPOSITION   = 0x010D;
          public const int WM_IME_ENDCOMPOSITION     = 0x010E;
          public const int WM_IME_COMPOSITION        = 0x010F;
          public const int WM_IME_KEYLAST            = 0x010F;

          /// <summary>在一个对话框程序被显示前发送此消息给它，通常用此消息初始化控件和执行其它任务。</summary>
          public const int WM_INITDIALOG             = 0x0110;

          /// <summary>当用户选择一条菜单命令项或当某个控件发送一条消息给它的父窗口，一个快捷键被翻译。</summary>
          public const int WM_COMMAND                = 0x0111;

          /// <summary>当用户选择窗口菜单的一条命令或当用户选择最大化或最小化时那个窗口会收到此消息。</summary>
          public const int WM_SYSCOMMAND             = 0x0112;

          /// <summary>发生了定时器事件。</summary>
          public const int WM_TIMER                  = 0x0113;

          /// <summary>当一个窗口标准水平滚动条产生一个滚动事件时发送此消息给那个窗口，也发送给拥有它的控件。</summary>
          public const int WM_HSCROLL                = 0x0114;

          /// <summary>当一个窗口标准垂直滚动条产生一个滚动事件时发送此消息给那个窗口也，发送给拥有它的控件。</summary>
          public const int WM_VSCROLL                = 0x0115;

          /// <summary>当一个菜单将要被激活时发送此消息，它发生在用户菜单条中的某项或按下某个菜单键，它允许程序在显示前更改菜单。</summary>
          public const int WM_INITMENU               = 0x0116;

          /// <summary>当一个下拉菜单或子菜单将要被激活时发送此消息，它允许程序在它显示前更改菜单，而不要改变全部。</summary>
          public const int WM_INITMENUPOPUP          = 0x0117;

          /// <summary>Undocumented, see http://www.microsoft.com/msj/0397/hood/hood0397.aspx</summary>
          public const int WM_SYSTIMER               = 0x0118;

          /// <summary>当用户选择一条菜单项时发送此消息给菜单的所有者（一般是窗口）。</summary>
          public const int WM_MENUSELECT             = 0x011F;

          /// <summary>当菜单已被激活用户按下了某个键（不同于加速键），发送此消息给菜单的所有者。</summary>
          public const int WM_MENUCHAR               = 0x0120;

          /// <summary>当一个模态对话框或菜单进入空载状态时发送此消息给它的所有者，一个模态对话框或菜单进入空载状态就是在处理完一条或几条先前的消息后没有消息它的列队中等待。</summary>
          public const int WM_ENTERIDLE              = 0x0121;

          public const int WM_MENURBUTTONUP          = 0x0122;
          public const int WM_MENUDRAG               = 0x0123;
          public const int WM_MENUGETOBJECT          = 0x0124;
          public const int WM_UNINITMENUPOPUP        = 0x0125;
          public const int WM_MENUCOMMAND            = 0x0126;
          public const int WM_CHANGEUISTATE          = 0x0127;
          public const int WM_UPDATEUISTATE          = 0x0128;
          public const int WM_QUERYUISTATE           = 0x0129;
          
          /// <summary>移动鼠标</summary>
          public const int WM_MOUSEMOVE              = 0x0200;

          /// <summary>按下鼠标左键</summary>
          public const int WM_LBUTTONDOWN            = 0x0201;

          /// <summary>释放鼠标左键</summary>
          public const int WM_LBUTTONUP              = 0x0202;

          /// <summary>双击鼠标左键</summary>
          public const int WM_LBUTTONDBLCLK          = 0x0203;

          /// <summary>按下鼠标右键</summary>
          public const int WM_RBUTTONDOWN            = 0x0204;

          /// <summary>释放鼠标右键</summary>
          public const int WM_RBUTTONUP              = 0x0205;

          /// <summary>双击鼠标右键</summary>
          public const int WM_RBUTTONDBLCLK          = 0x0206;

          /// <summary>按下鼠标中键</summary>
          public const int WM_MBUTTONDOWN            = 0x0207;

          /// <summary>释放鼠标中键</summary>
          public const int WM_MBUTTONUP              = 0x0208;

          public const int WM_MINCLICK               = WM_LBUTTONDOWN;
          public const int WM_MAXCLICK               = WM_MBUTTONUP;

          /// <summary>双击鼠标中键</summary>
          public const int WM_MBUTTONDBLCLK          = 0x0209;

          /// <summary>当鼠标轮子转动时发送此消息个当前有焦点的控件</summary>
          public const int WM_MOUSEWHEEL             = 0x020A;

          /// <summary>当鼠标轮子转动时发送此消息个当前有焦点的控件</summary>
          public const int WM_MOUSELAST              = 0x020A;

          public const int WM_MOUSELAST_PRE_4        = 0x0209;
          public const int WM_MOUSELAST_4            = 0x020A;
          public const int WM_MOUSELAST_5            = 0x020D;

          public const int WM_XBUTTONDOWN            = 0x020B;
          public const int WM_XBUTTONUP              = 0x020C;
          public const int WM_XBUTTONDBLCLK          = 0x020D;

          /// <summary>当MDI子窗口被创建或被销毁，或用户按了一下鼠标键而光标在子窗口上时发送此消息给它的父窗口。</summary>
          public const int WM_PARENTNOTIFY           = 0x0210;

          /// <summary>发送此消息通知应用程序的主窗口that已经进入了菜单循环模式。</summary>
          public const int WM_ENTERMENULOOP          = 0x0211;

          /// <summary>发送此消息通知应用程序的主窗口that已退出了菜单循环模式。</summary>
          public const int WM_EXITMENULOOP           = 0x0212;

          public const int WM_NEXTMENU               = 0x0213;

          /// <summary>当用户正在调整窗口大小时发送此消息给窗口；通过此消息应用程序可以监视窗口大小和位置也可以修改他们。</summary>
          public const int WM_SIZING                 = 0x0214;

          /// <summary>发送此消息给窗口当它失去捕获的鼠标时。</summary>
          public const int WM_CAPTURECHANGED         = 0x0215;

          /// <summary>当用户在移动窗口时发送此消息，通过此消息应用程序可以监视窗口大小和位置也可以修改他们。</summary>
          public const int WM_MOVING                 = 0x0216;

          /// <summary>此消息发送给应用程序来通知它有关电源管理事件。</summary>
          public const int WM_POWERBROADCAST         = 0x0218;

          /// <summary>当设备的硬件配置改变时发送此消息给应用程序或设备驱动程序。</summary>
          public const int WM_DEVICECHANGE           = 0x0219;

          /// <summary>应用程序发送此消息给多文档的客户窗口来创建一个MDI 子窗口。</summary>
          public const int WM_MDICREATE              = 0x0220;

          /// <summary>应用程序发送此消息给多文档的客户窗口来关闭一个MDI 子窗口。</summary>
          public const int WM_MDIDESTROY             = 0x0221;

          /// <summary>应用程序发送此消息给多文档的客户窗口通知客户窗口激活另一个MDI子窗口，当客户窗口收到此消息后，它发出WM_MDIACTIVE消息给MDI子窗口（未激活）激活它。</summary>
          public const int WM_MDIACTIVATE            = 0x0222;

          /// <summary>程序发送此消息给MDI客户窗口让子窗口从最大最小化恢复到原来大小。</summary>
          public const int WM_MDIRESTORE             = 0x0223;

          /// <summary>程序发送此消息给MDI客户窗口激活下一个或前一个窗口。</summary>
          public const int WM_MDINEXT                = 0x0224;

          /// <summary>程序发送此消息给MDI客户窗口来最大化一个MDI子窗口。</summary>
          public const int WM_MDIMAXIMIZE            = 0x0225;

          /// <summary>程序发送此消息给MDI客户窗口以平铺方式重新排列所有MDI子窗口。</summary>
          public const int WM_MDITILE                = 0x0226;

          /// <summary>程序发送此消息给MDI客户窗口以层叠方式重新排列所有MDI子窗口。</summary>
          public const int WM_MDICASCADE             = 0x0227;

          /// <summary>程序发送此消息给MDI客户窗口重新排列所有最小化的MDI子窗口。</summary>
          public const int WM_MDIICONARRANGE         = 0x0228;

          /// <summary>程序发送此消息给MDI客户窗口来找到激活的子窗口的句柄。</summary>
          public const int WM_MDIGETACTIVE           = 0x0229;

          /// <summary>程序发送此消息给MDI客户窗口用MDI菜单代替子窗口的菜单。</summary>
          public const int WM_MDISETMENU             = 0x0230;

          public const int WM_ENTERSIZEMOVE          = 0x0231;
          public const int WM_EXITSIZEMOVE           = 0x0232;
          public const int WM_DROPFILES              = 0x0233;
          public const int WM_MDIREFRESHMENU         = 0x0234;
          public const int WM_IME_SETCONTEXT         = 0x0281;
          public const int WM_IME_NOTIFY             = 0x0282;
          public const int WM_IME_CONTROL            = 0x0283;
          public const int WM_IME_COMPOSITIONFULL    = 0x0284;
          public const int WM_IME_SELECT             = 0x0285;
          public const int WM_IME_CHAR               = 0x0286;
          public const int WM_IME_REQUEST            = 0x0288;
          public const int WM_IME_KEYDOWN            = 0x0290;
          public const int WM_IME_KEYUP              = 0x0291;
          public const int WM_NCMOUSEHOVER           = 0x02A0;
          public const int WM_MOUSEHOVER             = 0x02A1;
          public const int WM_NCMOUSELEAVE           = 0x02A2;
          public const int WM_MOUSELEAVE             = 0x02A3;

          /// <summary>The WM_WTSSESSION_CHANGE message notifies applications of changes in session state.</summary>
          public const int WM_WTSSESSION_CHANGE      = 0x02B1;

          public const int WM_TABLET_FIRST           = 0x02C0;
          public const int WM_TABLET_LAST            = 0x02DF;

          /// <summary>程序发送此消息给一个编辑框或combobox来删除当前选择的文本。</summary>
          public const int WM_CUT                    = 0x0300;

          /// <summary>程序发送此消息给一个编辑框或combobox来复制当前选择的文本到剪贴板。</summary>
          public const int WM_COPY                   = 0x0301;

          /// <summary>程序发送此消息给editcontrol或combobox从剪贴板中得到数据。</summary>
          public const int WM_PASTE                  = 0x0302;

          /// <summary>程序发送此消息给editcontrol或combobox清除当前选择的内容。</summary>
          public const int WM_CLEAR                  = 0x0303;

          /// <summary>程序发送此消息给editcontrol或combobox撤消最后一次操作。</summary>
          public const int WM_UNDO                   = 0x0304;
          public const int WM_RENDERFORMAT           = 0x0305;
          public const int WM_RENDERALLFORMATS       = 0x0306;

          /// <summary>当调用ENPTYCLIPBOARD函数时 发送此消息给剪贴板的所有者。</summary>
          public const int WM_DESTROYCLIPBOARD       = 0x0307;

          /// <summary>当剪贴板的内容变化时发送此消息给剪贴板观察链的第一个窗口；它允许用剪贴板观察窗口来显示剪贴板的新内容。</summary>
          public const int WM_DRAWCLIPBOARD          = 0x0308;

          /// <summary>当剪贴板包含CF_OWNERDIPLAY格式的数据并且剪贴板观察窗口的客户区需要重画。</summary>
          public const int WM_PAINTCLIPBOARD         = 0x0309;

          public const int WM_VSCROLLCLIPBOARD       = 0x030A;

          /// <summary>当剪贴板包含CF_OWNERDIPLAY格式的数据并且剪贴板观察窗口的客户区域的大小已经改变是此消息通过剪贴板观察窗口发送给剪贴板的所有者。</summary>
          public const int WM_SIZECLIPBOARD          = 0x030B;

          /// <summary>通过剪贴板观察窗口发送此消息给剪贴板的所有者来请求一个CF_OWNERDISPLAY格式的剪贴板的名字。</summary>
          public const int WM_ASKCBFORMATNAME        = 0x030C;

          /// <summary>当一个窗口从剪贴板观察链中移去时发送此消息给剪贴板观察链的第一个窗口。</summary>
          public const int WM_CHANGECBCHAIN          = 0x030D;

          /// <summary>此消息通过一个剪贴板观察窗口发送给剪贴板的所有者；它发生在当剪贴板包含CFOWNERDISPALY格式的数据并且有个事件在剪贴板观察窗的水平滚动条上；所有者应滚动剪贴板图象并更新滚动条的值。</summary>
          public const int WM_HSCROLLCLIPBOARD       = 0x030E;

          /// <summary>此消息发送给将要收到焦点的窗口，此消息能使窗口在收到焦点时同时有机会实现他的逻辑调色板。</summary>
          public const int WM_QUERYNEWPALETTE        = 0x030F;

          /// <summary>当一个应用程序正要实现它的逻辑调色板时发此消息通知所有的应用程序。</summary>
          public const int WM_PALETTEISCHANGING      = 0x0310;

          /// <summary>此消息在一个拥有焦点的窗口实现它的逻辑调色板后发送此消息给所有顶级并重叠的窗口，以此来改变系统调色板。</summary>
          public const int WM_PALETTECHANGED         = 0x0311;

          /// <summary>当用户按下由REGISTERHOTKEY函数注册的热键时提交此消息。</summary>
          public const int WM_HOTKEY                 = 0x0312;

          /// <summary>应用程序发送此消息仅当WINDOWS或其它应用程序发出一个请求要求绘制一个应用程序的一部分。</summary>
          public const int WM_PRINT                  = 0x0317;
          public const int WM_PRINTCLIENT            = 0x0318;
          public const int WM_APPCOMMAND             = 0x0319;
          public const int WM_THEMECHANGED           = 0x031A;

          /// <summary>Sent when the contents of the clipboard have changed.</summary>
          public const int WM_CLIPBOARDUPDATE        = 0x031D;

          public const int WM_DWMCOMPOSITIONCHANGED  = 0x031E;
          public const int WM_HANDHELDFIRST          = 0x0358;
          public const int WM_HANDHELDLAST           = 0x035F;
          public const int WM_AFXFIRST               = 0x0360;
          public const int WM_AFXLAST                = 0x037F;
          public const int WM_PENWINFIRST            = 0x0380;
          public const int WM_PENWINLAST             = 0x038F;
          public const int WM_APP                    = 0x8000;
          public const int WM_USER                   = 0x00000400;
          
		public const int WM_XREDRAW                = WM_USER + 100;
		public const int WM_XREDRAWC               = WM_USER + 101;
		public const int WM_USER7441               = WM_USER + 7441;

          public const int WM_REFLECT                = WM_USER + 0x1c00;

          public const int
                         HWND_DESKTOP = 0x0000,
                         HWND_BROADCAST = 0xFFFF,
                         HWND_TOP = (0),
                         HWND_BOTTOM = (1),
                         HWND_TOPMOST = (-1),
                         HWND_NOTOPMOST = (-2),
                         HWND_MESSAGE = (-3);
     }

     public class SendMessageTimeoutFlags
     {
          public const int SMTO_NORMAL = 0x000000000;

          public const int SMTO_BLOCK = 0x000000001;

          public const int SMTO_ABORTIFHUNG = 0x000000002;

          public const int SMTO_NOTIMEOUTIFNOTHUNG = 0x000000008;

          public const int SMTO_ERRORONEXIT = 0x000000001;
     }

     /// <summary>define the window menu message.</summary>
     public enum WindowMenuMessage : int
     {
          SC_SIZE = 0xF000,
          SC_MOVE = 0xF010,
          SC_DRAGMOVE = 0xF012,
          SC_MINIMIZE = 0xF020,
          SC_MAXIMIZE = 0xF030,
          SC_NEXTWINDOW = 0xF040,
          SC_PREVWINDOW = 0xF050,
          SC_CLOSE = 0xF060,
          SC_VSCROLL = 0xF070,
          SC_HSCROLL = 0xF080,
          SC_MOUSEMENU = 0xF090,
          SC_SYSMENU = 0xF093,
          SC_KEYMENU = 0xF100,
          SC_ARRANGE = 0xF110,
          SC_RESTORE = 0xF120,
          SC_TASKLIST = 0xF130,
          SC_SCREENSAVE = 0xF140,
          SC_HOTKEY = 0xF150,
          SC_DEFAULT = 0xF160,
          SC_MONITORPOWER = 0xF170,
          SC_CONTEXTHELP = 0xF180,
          SC_SEPARATOR = 0xF00F,
          SC_MASK = 0xFFF0,
     }
}