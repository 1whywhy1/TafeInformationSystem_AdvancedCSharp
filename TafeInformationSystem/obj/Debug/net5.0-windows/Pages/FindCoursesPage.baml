   M S B A M L   `   `   `  ����P  LTafeInformationSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:TafeInformationSystem.PagesTafeInformationSystem.Pages  5      1    +TafeInformationSystem.Pages.FindCoursesPage   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:TafeInformationSystem.Pages     5        N� Title$  FindCoursesPage��5	      .��5      �  � ColumnDefinitions 5   
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
��auto �6   �� 5      $
��auto �6(   �� 5       $
��auto �6   �� 5!      $��* �6   �� 5"      $��10 �6   .+�5%   
   �� $��7��6   $��1��6!   $��	Search by��5&      �� 5'   
   $��7��6   $��2��6!   $��Search Criteria��5(      �� 5)   
   -   5         ��Name$ searchBycmb��5)      $��8��5*      $��1��6    $��	0,5,10,10q�5+      .@�5,      ��  �� 
IsSelected$
 True��6   .��6-   ID5.      �� 5/      .��6   Name51      �� 52      .��6   By Location54      �� 55      .��6   History by Teacher ID57      �� 58      .��6   No Location5:      5;      �� 5<   
   -   5         ��Name$ searchCriteriaText��5<      $��8��5=      $��2��6   $��50��5>      $��	0,5,10,10q�6    5?      �� 5A   
   $��9��6   $��1��6!   $��Courses��5B      �� 5C   
   -   5         ��Name$ coursesListView��5C      $��11��5D      $��1��6#   $��2��5E      $	��300��5F      $	��150��6$   $��	0,5,10,10q�5G      $
��True��6(    �� View 5H      �� 5I      .P�5J      �� $��	Course ID��6%    �� Width$ 80��68   	 �� DisplayMemberBinding	 6C   �� *
CourseID+�� 5K      $
��Name��6%   $	 250��63   	 6?   �� *Name+5N      5P      �� 5Y   
   $��1��6   $��4��6"   $��14��5Z      
 �� Orientation$
 Vertical=�6'   .+�5[      �� -   5         ��Name$ searchButton��5[      $��Search��6+   $��5,5,10,0q�5\      $��50��6#   $��0q�5]      $��16(�5^      ���	#FF252526���	#FFE7E7E86M   �� 5a      -   5        $ clearButton��5a      $��Clear��6*   $��5,5,10,0q�5b      $��50��6#   $��0q�5c      $��16(�5d      ���	#FF252526���	#FFE7E7E86M   �� 5g      -   5        $ 
openButton��5g      $��Open Selected��6)   $��	5,55,10,0q�5h      $��50��6$   $��0q�5i      $��16(�5j      ���	#FF252526���	#FFE7E7E86M   �� 5m      -   5        $ 
menuButton��5m      $��To Menu��6)   $��
5,300,10,0q�5n      $��50��6%   $��0q�5o      $��16(�5p      ���	#FF252526���	#FFE7E7E86M   5t      5v      5w      