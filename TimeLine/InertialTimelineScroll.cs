using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TimeLine
{
    public class InertialTimelineScroll
    {
        public event Action<Point> OnDragStart;
        public event Action<Point> OnDragStop;
        public event Action<Point, Point> OnDragMove;
        public event Action<Point> OnDoubleClick;

        FrameworkElement m_element;

        public InertialTimelineScroll(FrameworkElement fe)
        {
            m_element = fe;
            m_element.MouseLeftButtonUp += OnDragMouseUp;
            m_element.MouseLeftButtonDown += OnDragMouseDown;
            m_element.MouseMove += OnMouseMove;

        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnDragMouseDown(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnDragMouseUp(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
