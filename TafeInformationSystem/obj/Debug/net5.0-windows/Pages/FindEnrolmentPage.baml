   M S B A M L   `   `   `  ����P  LTafeInformationSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:TafeInformationSystem.PagesTafeInformationSystem.Pages  5      3    -TafeInformationSystem.Pages.FindEnrolmentPage   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:TafeInformationSystem.Pages     5        N� Title$  FindEnrolmentPage��5	      .��5      �  � ColumnDefinitions 5   
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
Student ID5+      �� 5,      .��6   Enrolment ID5.      5/      �� 50   
   -   5         ��Name$ searchCriteriaText��50      $��2��51      $��2��6"   $	��200��52      $��	0,5,10,10q�6$   �� 53   
   $��7��6   $��1��6!   $��	Enrolment��54      �� 55   
   -   5         ��Name$ enrolmentListView��55      $��9��56      $��1��6"   $��2��57      $	��300��58      $	��170��6$   $��	0,5,10,10q�59      $
��True��6(    �� View 5:      �� 5;      .P�5<      �� $��Enrolment ID��6%    �� Width$ 60��6;   	 �� DisplayMemberBinding	 6F   �� *enrolmentID+�� 5=      $��
Student ID��6%   $ 60��69   	 6D   �� *	studentID+�� 5>      $��
First Name��6%   $ 60��69   	 6D   �� *	firstName+�� 5?      $��	Last Name��6%   $ 80��68   	 6C   �� *
lastName+�� 5@      $��Course Name��6%   $ 80��6:   	 6E   �� *
courseName+�� 5A      $��
Payment ID��6%   $ 60��69   	 6D   �� *	paymentID+5B      5D      �� 5E   
   $��1��6   $��4��6"   $��14��5F      
 �� Orientation$
 Vertical=�6'   .+�5G      �� -   5         ��Name$ searchButton��5G      $��Search��6+   $��5,5,10,0q�5H      $��50��6#   $��0q�5I      $��16(�5J      ���	#FF252526���	#FFE7E7E86M   �� 5L      -   5        $ clearButton��5L      $��Clear��6*   $��5,5,10,0q�5M      $��50��6#   $��0q�5N      $��16(�5O      ���	#FF252526���	#FFE7E7E86M   �� 5Q      -   5        $ 
openButton��5Q      $��Open Selected��6)   $��5,5,10,0q�5R      $��50��6#   $��0q�5S      $��16(�5T      ���	#FF252526���	#FFE7E7E86M   �� 5V      -   5        $ deleteButton��5V      $��Delete��6+   $��	5,50,10,0q�5W      $��50��6$   $��1q�5X      ���	#FF818185$��16(�5Y      ���	#FF121212���	#FFE7E7E86M   �� 5\      -   5        $ 
menuButton��5\      $��To Menu��6)   $��	5,25,10,0q�5]      $��50��6$   $��0q�5^      $��16(�5_      ���	#FF252526���	#FFE7E7E86M   5a      5b      5c      