   M S B A M L   `   `   `  ����P  LTafeInformationSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:TafeInformationSystem.PagesTafeInformationSystem.Pages  5      -    'TafeInformationSystem.Pages.CoursesPage   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:TafeInformationSystem.Pages     5        N� 
FontFamily$  Korolev)�5	       N� FontSize$ 14(�6    N� Title$ CoursesPage��5
      .��5      �  � ColumnDefinitions 5   
   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��10 �6    � RowDefinitions 5   
   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��10 �6   .+�5   	   �� $��1��6   $��1��6    $��Course Name��5       �� 5!   
   $��1��6   $��2��6!   $��	Course ID��5"      �� 5#   
   -   5         ��Name$ courseNameText��5#      $��2��5$      $��1��6"   $	��200��5%      $��	0,5,10,10q�6$   �� 5&   
   -   5        $ idText��5&      $��2��5'      $��2��6"   ${�false��5(      $	��200��5)      $��	0,5,10,10q�6$   �� 5+   
   $��5��6   $��1��6!   $��Description��5,      �� 5-   
   -   5        $ descriptionText��5-      $��6��5.      $��1��6   $��Stretch=�5/      $��2��50      $��2��6#   $	��300��51      $��80��6!   $��	0,5,10,10q�60   �� 52   
   $��1��6   $��3��6"   $��14��53       �� Orientation$ Vertical=�6'   .+�54      �� -   5         ��Name$ 	newButton��54      $��
Add Course��6(   $��5,5,10,0q�55      $��50��6'   $��0q�56      $��16(�57      ���	#FF252526���	#FFE7E7E86Q   �� 59      -   5        $ 
editButton��59      $
��Edit��6)   $��5,5,10,0q�5:      $��50��6'   $��0q�5;      $��16(�5<      ���	#FF252526���	#FFE7E7E86Q   �� 5>      -   5        $ updateButton��5>      $��Save/Update��6+   $��5,5,10,0q�5?      $��50��6'   $��0q�5@      $��16(�5A      ���	#FF252526���	#FFE7E7E86Q   �� 5C      -   5        $ clearButton��5C      $��Clear��6*   $��	5,50,10,0q�5D      $��50��6$   $��0q�5E      $��16(�5F      ���	#FF252526���	#FFE7E7E86M   �� 5I      -   5        $ deleteButton��5I      $��Delete��6+   $��
5,115,10,0q�5J      $��50��6)   $��1q�5K      ���	#FF818185$��16(�5L      ���	#FF121212���	#FFE7E7E86Q   �� 5N      -	   5        $ 
menuButton��5N      $
��Back��6)   $��	5,90,10,0q�5O      $��50��6(   $��0q�5P      $��16(�5Q      ���	#FF252526���	#FFE7E7E86Q   5S      5T      5U      