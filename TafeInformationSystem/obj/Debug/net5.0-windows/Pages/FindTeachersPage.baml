   M S B A M L   `   `   `  ����P  LTafeInformationSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:TafeInformationSystem.PagesTafeInformationSystem.Pages  5      1    +TafeInformationSystem.Pages.FindTeacherPage   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:TafeInformationSystem.Pages     5        N� Title$  FindTeacherPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��10 �6    � RowDefinitions 5   
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
Teacher ID5+      �� 5,      .��6   
First Name5.      �� 5/      .��6   	Last Name51      �� 52      .��6   Location Name54      55      �� 56   
   -   5         ��Name$ searchCriteriaText��56      $��2��57      $��2��6"   $	��200��58      $��	0,5,10,10q�6$   �� 59   
   $��7��6   $��1��6!   $��Teachers��5:      �� 5;   
   -   5         ��Name$ teachersListView��5;      $��9��5<      $��1��6"   $��2��5=      $	��300��5>      $	��170��6$   $��	0,5,10,10q�5?      $
��True��6(    �� View 5@      �� 5A      .P�5B      �� $��
Teacher ID��6%    �� Width$ 60��69   	 �� DisplayMemberBinding	 6D   �� *	TeacherID+�� 5C      $��
First Name��6%   $ 60��69   	 6D   �� *	FirstName+�� 5D      $��	Last Name��6%   $ 80��68   	 6C   �� *
LastName+�� 5E      $��Date of Birth��6%   $	 100��6<   	 6H   �� *DOB+
 �� StringFormat$
 
dd-MM-yyyy��5F      5H      �� 5I   
   $��1��6   $��4��6"   $��14��5J       �� Orientation$ Vertical=�6'   .+�5K      �� -   5         ��Name$ searchButton��5K      $��Search��6+   $��5,5,10,0q�5L      $��50��6#   $��0q�5M      $��16(�5N      ���	#FF252526���	#FFE7E7E86M   �� 5P      -   5        $ clearButton��5P      $��Clear��6*   $��5,5,10,0q�5Q      $��50��6#   $��0q�5R      $��16(�5S      ���	#FF252526���	#FFE7E7E86M   �� 5U      -   5        $ 
openButton��5U      $��Open Selected��6)   $��5,5,10,0q�5V      $��50��6#   $��0q�5W      $��16(�5X      ���	#FF252526���	#FFE7E7E86M   �� 5Z      -   5        $ deleteButton��5Z      $��Delete��6+   $��	5,50,10,0q�5[      $��50��6$   $��1q�5\      ���	#FF818185$��16(�5]      ���	#FF121212���	#FFE7E7E86M   �� 5`      -   5        $ 
menuButton��5`      $��To Menu��6)   $��	5,25,10,0q�5a      $��50��6$   $��0q�5b      $��16(�5c      ���	#FF252526���	#FFE7E7E86M   5e      5f      5g      