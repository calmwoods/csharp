using System;

namespace MealMenu
{
    class MenuItem
    {
        public string  Time    { get; set; }
        public string  Name    { get; set; }
        public decimal Cost    { get; set; }
        public decimal Price   { get; set; }

        public MenuItem( string time, string name, decimal cost)
        {
            Time = time;
            Name = name;
            Cost = cost;
            Price = cost * 1.8m; 
        }

        public static MenuItem[] GetMenuListByTime(string time, MenuItem[] arrMenuItem)
        {
            int menuCnt = 0;
            for( int i=0; i < arrMenuItem.Length; i ++ )
            {
                if (arrMenuItem[i].Time.IndexOf(time) >= 0 )
                    menuCnt ++ ; 
            }

            MenuItem[] menuList = new MenuItem[menuCnt];
            int menuListIdx = 0; 
            for (int i = 0; i < arrMenuItem.Length; i ++ )
            {
                if (arrMenuItem[i].Time.IndexOf(time) >= 0 )
                {
                    menuList[menuListIdx] = arrMenuItem[i];
                    menuListIdx++; 
                }   
            }

            MenuItem temp ;
            for (int i = 0; i < menuListIdx; i++)
            {
                for (int j = i + 1; j < menuListIdx; j++)
                {
                    if (menuList[i].Name.CompareTo(menuList[j].Name) > 0)
                    {
                        temp = menuList[i];
                        menuList[i] = menuList[j];
                        menuList[j] = temp;
                    }
                }
            }    

            return menuList; 
        }

    }
}
