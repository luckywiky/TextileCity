using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextileCity.Models
{
    public enum Navigation
    {
        None=-1,
        Index =0,
        Fabric=1,
        Accessory=2,
        News=3,
        About=4,
        Location=5,
        Account=6
    }

    public class NaviCss
    {
        private string index = string.Empty;
        public string Index
        {
            get { return index; }          
        }

        private string fabric = string.Empty;

        public string Fabric
        {
            get { return fabric; }         
        }

        private string accessory = string.Empty;

        public string Accessory
        {
            get { return accessory; }           
        }

        private string news = string.Empty;

        public string News
        {
            get { return news; }
            set { news = value; }
        }

        private string about = string.Empty;

        public string About
        {
            get { return about; }
        }

        private string location = string.Empty;

        public string Location
        {
            get { return location; }
        }
        private string account = string.Empty;

        public string Account
        {
            get { return account; }
        }

        private Navigation current = Navigation.None;
        public Navigation Current
        {
            get { return current; }
            set
            {
                SetCurrent(value);
                current = value;
            }
        }

        public void SetCurrent(Navigation current)
        {
            index = string.Empty;
            fabric = string.Empty;
            accessory = string.Empty;
            news = string.Empty;
            about = string.Empty;
            location = string.Empty;
            account = string.Empty;
            string css = "active";
            switch (current)
            {
                case Navigation.Index:
                    index = css;
                    break;
                case Navigation.Fabric:
                    fabric = css;
                    break;
                case Navigation.Accessory:
                    accessory = css;
                    break;
                case Navigation.News:
                    news = css;
                    break;
                case Navigation.About:
                    about = css;
                    break;
                case Navigation.Location:
                    location = css;
                    break;
                case Navigation.Account:
                    account = css;
                    break;
            }

        }


    }

}