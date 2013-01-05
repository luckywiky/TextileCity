using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextileCity.Entity
{
    public class Pager
    {
        public static int DefaultSize
        {
            get { return 20; }
        }

        public static int DefaultDisplayCount
        {
            get { return 7; }
        }

        public Pager(int page, int itemsCount, int size)
        {
            pageIndex = page;
            if (itemsCount % size == 0)
            {
                pageCount = itemsCount / size;
            }
            else
            {
                pageCount = itemsCount / size + 1;
            }
            pageSize = size;
        }

        public Pager()
        {
        }

        
        private int pageCount = 1;

        public int Count
        {
            get { return pageCount; }
            set { pageCount = value; }
        }

        private int pageIndex = 1;

        public int Index
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }
        private int pageSize = Pager.DefaultSize;

        public int Size
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        private int displayCount = Pager.DefaultDisplayCount;

        public int DisplayCount
        {
            get { return displayCount; }
            set { displayCount = value; }
        }

        private string nextText = "下一页";

        public string NextText
        {
            get { return nextText; }
            set { nextText = value; }
        }
        private string prevText = "上一页";

        public string PrevText
        {
            get { return prevText; }
            set { prevText = value; }
        }
        private string firstText = "首页";

        public string FirstText
        {
            get { return firstText; }
            set { firstText = value; }
        }
        private string lastText = "末页";

        public string LastText
        {
            get { return lastText; }
            set { lastText = value; }
        }

        public List<PagerItem> CreatePager()
        {
            return CreatePager(displayCount);
        }

        public List<PagerItem> CreatePager(int displayCount)
        {
            List<PagerItem> items = new List<PagerItem>();
            PagerItem firstItem = new PagerItem();
            firstItem.Index = 1;
            firstItem.Text = firstText;
            PagerItem prevItem = new PagerItem();
            prevItem.Text = prevText;
            if (pageIndex > 1)
            {
                firstItem.Display = true;
                prevItem.Index = pageIndex - 1;
                prevItem.Display = true;
            }
            else
            {
                firstItem.Display = false;
                prevItem.Display = false;
                prevItem.Index = 1;
            }

            PagerItem nextItem = new PagerItem();
            PagerItem lastItem = new PagerItem();
            nextItem.Text = nextText;
            lastItem.Text = lastText;
            lastItem.Index = pageCount;
            if (pageIndex < pageCount)
            {
                nextItem.Index = pageIndex + 1;
                nextItem.Display = true;
                lastItem.Display = true;
            }
            else
            {
                nextItem.Index = pageCount;
                nextItem.Display = false;                
                lastItem.Display = false;
            }

            int start = 1;
            int end = pageCount;

            if (pageCount <= displayCount)
            {
                start = 1;
                end = pageCount;
            }
            else
            {
                if (pageIndex < displayCount - 1)
                {
                    start = 1;
                    end = displayCount;
                }
                else
                {
                    if (pageIndex + displayCount / 2 >= pageCount)
                    {
                        start = pageCount - displayCount + 1;
                        end = pageCount;
                    }
                    else
                    {
                        start = pageIndex - displayCount / 2;
                        end = pageIndex + displayCount / 2 ;
                    }
                }
            }


           // items.Add(firstItem);
            items.Add(prevItem);

            for (int i = start; i <= end; i++)
            {
                PagerItem item = new PagerItem();
                item.Index = i;
                item.Text = i.ToString();
                item.Display = true;
                if (i == pageIndex)
                {
                    item.Active = true;
                }
                else
                {
                    item.Active = false;
                }
                items.Add(item);
            }

            items.Add(nextItem);
          //  items.Add(lastItem);

            return items;
        }

    }

    public class PagerItem
    {
        private bool active = false;
        public int Index
        {
            get;set;
        }
        public bool Display
        {
            get;set;
        }
        public bool Active
        {
            get { return active; }
            set { active = value; }
        }
        public string Text
        {
            get;
            set;
        }
    }
}
