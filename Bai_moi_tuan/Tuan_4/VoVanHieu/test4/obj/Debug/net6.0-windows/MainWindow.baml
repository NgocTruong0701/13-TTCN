   M S B A M L   `   `   `  ����@  <test4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:test4test4  5   	       test4.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:test4     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   $��20(�5	   	   .��5
      � .+�5   
   �� $��Ma benh nhan��6   $
��Left=�6'   $��	50,50,0,0q�6B   $	��Top=�6U   �� 5   
   $��Ho ten��6   $
��Left=�6!   $��
50,100,0,0q�6<   $	��Top=�6P   �� 5   
   $��	Khoa kham��6   $
��Left=�6$   $��
50,150,0,0q�6?   $	��Top=�6S   �� 5   
   $��So ngay nam vien��6   $
��Left=�6+   $��
50,200,0,0q�6F   $	��Top=�6Z   �� 5   
   -   5        $��txtmbn��5      $
��Left=�6    $��
250,50,0,0q�6;    �� TextWrapping$
 Wrap=�6O   $�� ��6c   $	��Top=�6k   $	��250��6�   �� 5   
   -   5        $��txtht��5      $
��Left=�6   $��250,100,0,0q�6:   $
 Wrap=�6O   $�� ��6c   $	��Top=�6k   $	��250��6�   �� 5   
   -   5        $��txtsnnv��5      $
��Left=�6!   $��250,200,0,0q�6<   $
 Wrap=�6Q   $�� ��6e   $	��Top=�6m   $	��250��6�   �� 5   
   -   5        $��cbokk��5       �� SelectedIndex$ 0��6    $
��Left=�62   $��250,150,0,0q�6M   $	��Top=�6b   $	��250��6z   �� 5   
   -   5        $��butthem��5      $
��Them��6    $
��Left=�6/   $��
600,50,0,0q�6J   $	��Top=�6^   6v   �� 5   
   -   5        $��buttim��5      $	��Tim��6   $
��Left=�6-   $��600,100,0,0q�6H   $	��Top=�6]   6u   �� 5   
   -   5        $��butxoa��5      $	��Xoa��6   $
��Left=�6-   $��600,150,0,0q�6H   $	��Top=�6]   6u   &   System.Windows.Controls.DataGrid  5   
   -	   5        $
��dsbn��5         AutoGenerateColumns$ False��6   $��
50,250,0,0q�6;   $	��600��6O      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Ma benh nhan��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *Mabn+  5      $ Ho ten��6%    65   �� *Hoten+  5      $ Ma khoa��6%    66   �� *Makhoa+  5      $ So ngay��6%    66   �� *
SongayNv+  5      $ Vien phi��6%    67   �� *	vienphi+5      5      5       