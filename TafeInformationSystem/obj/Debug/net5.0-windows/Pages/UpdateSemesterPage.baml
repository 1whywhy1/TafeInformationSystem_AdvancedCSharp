   M S B A M L   `   `   `  ����P  LTafeInformationSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:TafeInformationSystem.PagesTafeInformationSystem.Pages  5      4    .TafeInformationSystem.Pages.UpdateSemesterPage   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:TafeInformationSystem.Pages     5        N� Title$  UpdateSemesterPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��10 �6    � RowDefinitions 5   
   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��10 �6   .+�5"   
   �� $��1��6   $��1��6!   $��	0,15,0,20q�5#      $��3��5$      $��20(�5%      $��Add New Semester��5&      �� 5'   
   $��4��6   $��2��6!   $��	0,5,10,10q�5(      $��
Start Date��5)      (  "System.Windows.Controls.DatePicker  5+   
   -   5          Name$ startDP��5+      $��5��5,      $��2��6   $	��200��5-      $��	0,5,10,10q�6    �� 5/   
   $��4��6   $��4��6!   $��	0,5,10,10q�50      $��End Date��51      �� 53   
   $��2��6   $��2��6!   $��	0,5,10,10q�54      $��Semester ID��55        57   
   -   5        $ endDP��57      $��5��58      $��4��6"   $��	0,5,10,10q�59      $	��200��6(   5;      �� 5<   
   -   5         ��Name$ semesterIDText��5<      $��3��5=      $��2��6   $��2��5>      ${�False��5?      $	��200��5@      $��	0,5,10,10q�6    �� 5A   
   $��1��6   $��5��6"   $��14��5B       �� Orientation$ Vertical=�6'   .+�5C      �� -   5         ��Name$ 
editButton��5C      $��Edit Semester��6)   $��	5,10,10,0q�5D      $��50��6(   $��0q�5E      $��16(�5F      ���	#FF252526���	#FFE7E7E86Q   �� 5H      -   5        $ updateButton��5H      $��Update Semester��6+   $��	5,10,10,0q�5I      $��50��6(   $��0q�5J      $��16(�5K      ���	#FF252526���	#FFE7E7E86Q   �� 5M      -   5        $ cancelButton��5M      $��Cancel��6+   $��	5,10,10,0q�5N      $��50��6(   $��0q�5O      $��16(�5P      ���	#FF252526���	#FFE7E7E86:   �� 5R      -   5        $ deleteButton��5R      $��Delete��6+   $��	5,50,10,0q�5S      $��50��6(   $��0q�5T      $��16(�5U      ���	#FF121212���	#FFE7E7E86:   �� 5X      -   5        $ 
menuButton��5X      $
��Back��6)   $��	5,90,10,0q�5Y      $��50��6(   $��0q�5Z      $��16(�5[      ���	#FF252526���	#FFE7E7E86Q   5]      5^      5_      