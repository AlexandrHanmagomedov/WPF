   M S B A M L   `   `   `  ????B  >TestApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:TestApp.ModelTestApp.Model  5   	   !    TestApp.SelectProductWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:TestApp.Model     5   	     ? Title$  SelectProductWindow??5   	   $	??450??6%   $	??800??62    ? 	Resources 5       ?? DataType   TestApp.Model.Folder ?? ItemsSource ?? Path   TestApp.Model.ProductNode??%?  (??       5   #   *, +)(?? ?     5      *, +)?? 5   
   "  6#    5   #   ?? *Nodes+.R?5      ]? .+?5      ?? $??Resources\folder.png??6   $??48??5      $
??Left=?5      $??Center=?5      ?? 5      ??6   ?? $
 Name?5      5      ?? 5   
   "  6   .R?5      ]? .+?5      ?? $??Resources\candy.png??6   $??48??5      $
??Left=?5      $??Center=?5      ?? 5      ??6   ?? $
 Name?5      5       5!      .??5$      ?  ? RowDefinitions 5&   
   ?? 5'      $
??auto ?6   ?? 5(      ?? 5)      $
??auto ?6   .+?5,   
   ? $??1??6   .+?5-      R? -   5         R?Name$ ProductsTree??5-      5.      ? 50   
   $??2??6   .+?51      ? $	??300??6    ? ColumnDefinitions 52      ?? 53      ?? 54      $??20 ?6'   ?? 55      .+?57      ?? -   5        $??0??57      .??58   .   Выбрать67   ?? 59      $??2??6   .??6)   Отмена61   5:      5;      5B      5C      