   M S B A M L   `   `   `  ����G  Contapcackieu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ontapcackieuontapcackieu  5   	       ontapcackieu.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ontapcackieu     5   	   -   5          � Title$  
MainWindow��5   	   $	��600��6   $	��800��6)   .��5	      � $	��590��6   $	��Top=�6   .+�5
   
   �� $��Mã sản phẩm��6   $
��Left=�6&   $��
100,50,0,0q�6A   $	��Top=�6U   �� 5   
   $��Tên sản phẩm��6   $
��Left=�6'   $��100,100,0,0q�6B   $	��Top=�6W   �� 5   
   $��Tên Loại��6   $
��Left=�6#   $��100,150,0,0q�6>   $	��Top=�6S   �� 5   
   $��Số lượng��6   $
��Left=�6#   $��100,200,0,0q�6>   $	��Top=�6S   �� 5   
   $��
Đơn giá��6   $
��Left=�6"   $��100,250,0,0q�6=   $	��Top=�6R   �� 5   
   -   5         ��Name$ txtMsp��5      $
��Left=�6"   $��
250,50,0,0q�6=   $�� ��6Q    �� TextWrapping$
 Wrap=�6Y   $	��Top=�6m   $	��120��6�   �� 5   
   -   5        $ txtTsp��5      $
��Left=�6#   $��250,100,0,0q�6>   $�� ��6S   $
 Wrap=�6[   $	��Top=�6o   $	��120��6�   �� 5   
   -   5        $ txtSl��5      $
��Left=�6!   $��250,200,0,0q�6<   $�� ��6Q   $
 Wrap=�6Y   $	��Top=�6m   $	��120��6�   �� 5   
   -   5        $ txtDG��5      $
��Left=�6!   $��250,250,0,0q�6<   $�� ��6Q   $
 Wrap=�6Y   $	��Top=�6m   $	��120��6�   �� 5   
   -   5        $��
cboTenLoai��5      $
��Left=�6%   $��250,150,0,0q�6@   $	��Top=�6U   $	��120��6m   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dg��5      $��	0,294,0,0q�6      AutoGenerateColumns$ False��62      CanUserAddRows$ False��6N   $	��195��6e   $	��Top=�6r      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã Sản Phẩm��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *MaSp+  5      $ Tên sản phẩm��6%    6;   �� *TenSp+  5      $ 
Mã Loại��6%    66   �� *MaLoai+  5      $ Số lượng��6%    67   �� *	SoLuong+  5      $ 
Đơn giá��6%    66   �� *DonGia+  5      $ Thành tiền��6%    69   �� *	ThanhTien+5      �� 5   
   -   5        $��Thêm��5      $
��Left=�6    $��126,544,0,0q�6;   $	��Top=�6P   6h   5!      5"      