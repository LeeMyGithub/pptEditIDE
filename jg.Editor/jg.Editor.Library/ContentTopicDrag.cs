using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;
using System.IO;
using System.Collections.ObjectModel;

namespace jg.Editor.Library
{
    [Serializable]
    public class ContentTopicDrag : abstractContent
    {
        public ContentTopicDrag()
        {
            topicDragItemAnswerList = new ObservableCollection<Control.TopicDragItemAnswerInfo>();
            topicDragItemList = new ObservableCollection<Control.TopicDragItemInfo>();

        }
        [XmlAttribute("Background")]
        public string Background { get; set; }
        [XmlAttribute("Foreground")]
        public string Foreground { get; set; }


        [XmlAttribute("AnswerBackground")]
        public string AnswerBackground { get; set; }
        [XmlAttribute("AnswerForeground")]
        public string AnswerForeground { get; set; }
        [XmlAttribute("Score")]
        public double Score { get; set; }

        public ObservableCollection<Control.TopicDragItemAnswerInfo> topicDragItemAnswerList { get; set; }
        public ObservableCollection<Control.TopicDragItemInfo> topicDragItemList { get; set; }
    }
}
