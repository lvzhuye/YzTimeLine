using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TimeLine
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:TimeLine"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:TimeLine;assembly=TimeLine"
    ///
    /// 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
    /// 并重新生成以避免编译错误: 
    ///
    ///     在解决方案资源管理器中右击目标项目，然后依次单击
    ///     “添加引用”->“项目”->[选择此项目]
    ///
    ///
    /// 步骤 2)
    /// 继续操作并在 XAML 文件中使用控件。
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    public class TimeLineBand : Control
    {

        private const string TP_MAIN_GRID_PART = "MainGrid";
        private const string TP_CANVAS_PART = "CanvasPart";
        private const string TP_NAVIGATE_LEFT_PART = "NavigateLeftButton";
        private const string TP_NAVIGATE_RIGHT_PART="NavigateRightButton";


        private Canvas m_canvasPart;

        public InertialTimelineScroll InertialScroll;
        private Button m_navigateLeftButton;
        private Button m_navigateRightButton;
        private TimelineCalendarType m_timelineType;

        public TimeLineCalendar ItemsSource { get; set; }

        public Grid MainGridPart
        {
            get;set;
        }

        public Canvas CanvasPart
        {
            get
            {
                return m_canvasPart;
            }

            set
            {
                if(m_canvasPart != null)
                {
                    if(InertialScroll != null)
                    {
                        InertialScroll.OnDragStart -= OnCanvasMouseLeftButtonDown;
                        InertialScroll.OnDragStop -= OnCanvasMouseLeftButtonUp;
                        InertialScroll.OnDragMove -= OnCanvasMouseMove;
                        //???
                        InertialScroll = null;
                    }

                    m_canvasPart.MouseWheel -= OnCanvasMouseWheel;
                    m_canvasPart.SizeChanged -= OnSizeChanged;
                }

                m_canvasPart = value;

                if(value != null)
                {
                    InertialScroll = new InertialTimelineScroll(m_canvasPart);

                    InertialScroll.OnDragStart += OnCanvasMouseLeftButtonDown;
                    InertialScroll.OnDragStop += OnCanvasMouseLeftButtonUp;
                    InertialScroll.OnDragMove += OnCanvasMouseMove;
                    InertialScroll.OnDoubleClick += OnCanvasDoubleClick;

                    m_canvasPart.MouseWheel += OnCanvasMouseWheel;
                    m_canvasPart.SizeChanged += OnSizeChanged;

                    m_canvasPart.DataContext = this;

                }
            }
        }

        public Button NavigateLeftButton
        {
            get
            {
                return m_navigateLeftButton;
            }

            set
            {
                if(m_navigateLeftButton != null)
                {
                    m_navigateLeftButton.Click -= OnNavigateLeftClick;
                }

                m_navigateLeftButton = value;

                if(m_navigateLeftButton != null)
                {
                    m_navigateLeftButton.Click += OnNavigateLeftClick;
                }
            }
        }

        public Button NavigateRightButton
        {
            get {
                return m_navigateRightButton;
            }

            set
            {
                if(m_navigateRightButton != null)
                {
                    m_navigateRightButton.Click -= OnNavigateRightClick;
                }

                m_navigateRightButton = value;

                if(m_navigateRightButton != null)
                {
                    m_navigateRightButton.Click += OnNavigateRightClick;
                }
            }
        }

        private void OnNavigateRightClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnNavigateLeftClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnCanvasDoubleClick(Point obj)
        {
            throw new NotImplementedException();
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnCanvasMouseWheel(object sender, MouseWheelEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnCanvasMouseMove(Point arg1, Point arg2)
        {
            throw new NotImplementedException();
        }

        private void OnCanvasMouseLeftButtonUp(Point obj)
        {
            throw new NotImplementedException();
        }

        private void OnCanvasMouseLeftButtonDown(Point obj)
        {
            throw new NotImplementedException();
        }

        static TimeLineBand()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimeLineBand), new FrameworkPropertyMetadata(typeof(TimeLineBand)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            MainGridPart = (Grid)GetTemplateChild(TP_MAIN_GRID_PART);

            CanvasPart = (Canvas)GetTemplateChild(TP_CANVAS_PART);

            NavigateLeftButton = (Button)GetTemplateChild(TP_NAVIGATE_LEFT_PART);

            NavigateRightButton = (Button)GetTemplateChild(TP_NAVIGATE_RIGHT_PART);


        }

        public void CreateTimeLineCalculator(
            string calendarType,
            DateTime currentDateTime,
            DateTime minDateTime,
            DateTime maxDateTime)
        {
            ItemsSource = new TimeLineCalendar(calendarType,m_timelineType,
                minDateTime,maxDateTime);
        }


    }
}
