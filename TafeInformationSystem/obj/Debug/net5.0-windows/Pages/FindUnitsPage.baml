   M S B A M L   `   `   `  ����P  LTafeInformationSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:TafeInformationSystem.PagesTafeInformationSystem.Pages  5      /    )TafeInformationSystem.Pages.FindUnitsPage   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:TafeInformationSystem.Pages     5        N� Title$  FindUnitsPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��10 �6    � RowDefinitions 5   
   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��10 �6   .+�5   
   �� $��1��6   $��1��6!   $��	Search by��5       �� 5!   
   $��1��6   $��2��6!   $��Search Criteria��5"      �� 5#   
   -   5         ��Name$ searchBycmb��5#      $��2��5$      $��1��6"   $	��200��5%      $��	0,5,10,10q�6$   .@�5&      ��  �� 
IsSelected$
 True��6   .��6-   	Unit ID5(      �� 5)      .��6   	Unit Name5+      �� 5,      .��6   	Course ID5.      �� 5/      .��6   Not Allowcated51      53      �� 54   
   -   5         ��Name$ searchCriteriaText��54      $��2��55      $��2��6"   $	��200��56      $��	0,5,10,10q�6$   57      �� 58   
   $��3��6   $��1��6!   $��Units��59      &   System.Windows.Controls.DataGrid  5:   
   -   5          Name$ unitsDataGrid��5:      $��5��6*   $��1��67   $��2��5;         
IsReadOnly$
 True��6)   5=      �� 5?   
   $��1��6   $��3��6"   $��14��5@       �� Orientation$ Vertical=�6'   .+�5A      �� -   5        	 ��Name$	 searchButton��5A      $��Search��6+   $��5,5,10,0q�5B      $��50��6'   $��0q�5C      $��16(�5D      ���	#FF252526���	#FFE7E7E86Q   �� 5F      -   5        $	 
openButton��5F      $��Open Selected��6)   $��5,5,10,0q�5G      $��50��6'   $��0q�5H      $��16(�5I      ���	#FF252526���	#FFE7E7E86Q   �� 5K      -   5        $	 clearButton��5K      $��Clear��6*   $��	5,30,10,0q�5L      $��50��6$   $��0q�5M      $��16(�5N      ���	#FF252526���	#FFE7E7E86M   �� 5P      -   5        $	 
menuButton��5P      $��To Menu��6)   $��	5,75,10,0q�5Q      $��50��6(   $��0q�5R      $��16(�5S      ���	#FF252526���	#FFE7E7E86Q   5U      5V      5W      