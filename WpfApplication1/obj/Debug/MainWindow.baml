   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	        WpfApplication1.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication1     5   	     � Title$  
MainWindow��5   	   $	��325��6   $��475.6��6)    � AllowsTransparency .  � WindowStyle$
 None=�6Q    � WindowStartupLocation$ CenterScreen=�6d    � WindowState$ 	Minimized=�6�   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��43* �6   �� 5      $	��22* �6    � ColumnDefinitions 5   
   �� 5      $
��263* �6   �� 5      $
��262* �6   .+�5   
   �� -   5         ��Name$ image��5      $
��Left=�6   $	��325��6:   $	��Top=�6G   $	��477��6_   $��0,0,-1.4,-0.2q�6k   $��bin/img/137362.jpg��6�   $
��Fill=�6�   $��2��6�   $��2��6�   �� 5   
   -   5         ��Name$
 exit��5      $��خروج��6   $��69,40.2,64.4,39.8q�6.   	 �� IsCancel	 . 
 � Cursor$

 None��6Y    J� RenderTransformOrigin$ 0.5,0.5&�6g   ���	#FF000105
�������$��1��6�   z�5      V� 5      .~�5      ��  �� ScaleY$ 1Q�6%    �� ScaleX$ 1Q�60   �� 5       �� AngleY$ 0Q�6$    �� AngleX$ 0Q�6/   �� 5       �� Angle$ 0Q�6&   T� 5      5      5      �� 5   
   -   5        $ enter��5      $��ورود��6    $��68.6,40.2,64.6,39.8q�6/   
����������	#FF000103$��1��6�   $��1��6�    �� 	IsDefault . 6�   �� 5   
   -   5         ��Name$ username��5      $
��Left=�6$   $��35��6?   $��
90,108,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��185��6�   ���	#FF8B80C4$��2��6�   �� 5   
   -   5         ��Name$ label��5      $��:نام کاربری��6   $
��Left=�65   $��35��6P   $��41.6,108,0,0q�6\   $	��Top=�6r   $	��100��6�   $��18(�6�   $��1��6�   �� 5    
   -   5        $ 
label_Copy��5       $��:رمز عبور��6$   $
��Left=�6:   $��35��6U   $��41.6,165,0,0q�6a   $	��Top=�6w   $	��100��6�   $��18(�6�   $��1��6�   G� 5!   
   -   5         G�Name$ password��5!      $
��Left=�6(   $��
90,165,0,0q�6C   $	��Top=�6W   $��35��6o   $	��185��6{   $��2��6�   ���	#FF8B80C46�   5#      5$      