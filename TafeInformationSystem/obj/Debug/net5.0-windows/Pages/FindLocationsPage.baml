   M S B A M L   `   `   `  ����P  LTafeInformationSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:TafeInformationSystem.PagesTafeInformationSystem.Pages  5      3    -TafeInformationSystem.Pages.FindLocationsPage   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:TafeInformationSystem.Pages     5        N� Title$  FindLocationsPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��10 �6    � RowDefinitions 5   
   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��10 �6   .+�5   
   �� $��1��6   $��1��6!   $��	Search by��5      �� 5   
   $��1��6   $��2��6!   $��Search Criteria��5       �� 5!   
   -   5         ��Name$ searchBycmb��5!      $��2��5"      $��1��6"   $	��200��5#      $��	0,5,10,10q�6$   .@�5$      ��  �� 
IsSelected$
 True��6   .��6-   Location ID5&      �� 5'      .��6   Name5)      �� 5*      .��6   
Postcode5,      5-      �� 5.   
   -   5         ��Name$ searchCriteriaText��5.      $��2��5/      $��2��6"   $	��200��50      $��	0,5,10,10q�6$   �� 51   
   $��3��6   $��1��6!   $��	Locations��52      �� 53   
   -   5         ��Name$ unitsListView��53      $��4��54      $��1��6"   $��2��55      $	��300��56      $	��170��6$   $��	0,5,10,10q�57      $
��True��6(    �� View 58      �� 59      .P�5:      �� $��Unit ID��6%    �� Width$ 80��66   	 �� DisplayMemberBinding	 6A   �� *unitID+�� 5;      $
��Name��6%   $	 250��63   	 6?   �� *
unitName+�� 5<      $��Point Value��6%   $ 30��6:   	 6E   �� *unitPointValue+�� 5=      $��Price��6%   $	 100��64   	 6@   �� *Price+5>      5@      �� 5A   
   $��1��6   $��3��6"   $��14��5B      
 �� Orientation$
 Vertical=�6'   .+�5C      �� -   5         ��Name$ searchButton��5C      $��Search��6+   $��5,5,10,0q�5D      $��50��6'   $��0q�5E      $��16(�5F      ���	#FF252526���	#FFE7E7E86Q   �� 5H      -   5        $ updateButton��5H      $��Open Selected��6+   $��5,5,10,0q�5I      $��50��6'   $��0q�5J      $��16(�5K      ���	#FF252526���	#FFE7E7E86Q   �� 5M      -   5        $ clearButton��5M      $��Clear��6*   $��	5,30,10,0q�5N      $��50��6$   $��0q�5O      $��16(�5P      ���	#FF252526���	#FFE7E7E86M   �� 5S      -   5        $ deleteButton��5S      $��Delete��6+   $��	5,50,10,0q�5T      $��50��6(   $��1q�5U      ���	#FF818185$��16(�5V      ���	#FF121212���	#FFE7E7E86Q   �� 5X      -   5        $ 
menuButton��5X      $��To Menu��6)   $��	5,75,10,0q�5Y      $��50��6(   $��0q�5Z      $��16(�5[      ���	#FF252526���	#FFE7E7E86Q   5]      5^      5_      