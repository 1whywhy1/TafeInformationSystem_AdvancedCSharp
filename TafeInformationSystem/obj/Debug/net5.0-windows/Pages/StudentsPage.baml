   M S B A M L   `   `   `  ����P  LTafeInformationSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:TafeInformationSystem.PagesTafeInformationSystem.Pages  5      .    (TafeInformationSystem.Pages.StudentsPage   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:TafeInformationSystem.Pages     5        N� Title$  StudentsPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��10 �6    � RowDefinitions 5   
   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5       $��10 �6   .+�5"   
   �� $��1��6   $��1��6!   $��	Search by��5#      �� 5$   
   $��1��6   $��2��6!   $��Search Criteria��5%      �� 5&   
   -   5         ��Name$ searchBycmb��5&      $��2��5'      $��1��6"   $	��200��5(      $��	0,5,10,10q�6$   .@�5)      ��  �� 
IsSelected$
 True��6   .��6-   
Student ID5+      �� 5,      .��6   
First Name5.      �� 5/      .��6   	Last Name51      �� 52      .��6   Enrolled, Not Paid54      �� 55      .��6   	Full Time57      �� 58      .��6   	Part Time5:      5;      �� 5<   
   -   5         ��Name$ searchCriteriaText��5<      $��2��5=      $��2��6"   $	��200��5>      $��	0,5,10,10q�6$   �� 5?   
   $��7��6   $��1��6!   $��Students��5@      �� 5A   
   -   5         ��Name$ studentsListView��5A      $��9��5B      $��1��6"   $��2��5C      $	��300��5D      $	��170��6$   $��	0,5,10,10q�5E      $
��True��6(    �� View 5F      �� 5G      .P�5H      �� $��
Student ID��6%    �� Width$ 60��69   	 �� DisplayMemberBinding	 6D   �� *	StudentID+�� 5I      $��
First Name��6%   $ 60��69   	 6D   �� *	FirstName+�� 5J      $��	Last Name��6%   $ 80��68   	 6C   �� *
LastName+�� 5K      $��Date of Birth��6%   $	 100��6<   	 6H   �� *DOB+
 �� StringFormat$
 
dd-MM-yyyy��5L      5N      �� 5O   
   $��1��6   $��4��6"   $��14��5P       �� Orientation$ Vertical=�6'   .+�5Q      �� -   5         ��Name$ searchButton��5Q      $��Search��6+   $��5,5,10,0q�5R      $��50��6#   $��0q�5S      $��16(�5T      ���	#FF252526���	#FFE7E7E86M   �� 5V      -   5        $ clearButton��5V      $��Clear��6*   $��5,5,10,0q�5W      $��50��6#   $��0q�5X      $��16(�5Y      ���	#FF252526���	#FFE7E7E86M   �� 5[      -   5        $ openSelectedButton��5[      $��Open Selected��61   $��5,5,10,0q�5\      $��50��6#   $��0q�5]      $��16(�5^      ���	#FF252526���	#FFE7E7E86M   �� 5`      -   5        $ deleteButton��5`      $��Delete��6+   $��	5,50,10,0q�5a      $��50��6$   $��1q�5b      ���	#FF818185$��16(�5c      ���	#FF121212���	#FFE7E7E86M   �� 5f      -   5        $ 
backButton��5f      $
��Back��6)   $��	5,25,10,0q�5g      $��50��6$   $��0q�5h      $��16(�5i      ���	#FF252526���	#FFE7E7E86M   5k      5l      5m      