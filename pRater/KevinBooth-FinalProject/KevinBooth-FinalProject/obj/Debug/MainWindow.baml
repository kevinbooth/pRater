   M S B A M L   `   `   `  ����R  NKevinBooth-FinalProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:KevinBooth_FinalProjectKevinBooth_FinalProject  5   	   (    "KevinBooth_FinalProject.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:KevinBooth_FinalProject     5   	     � WindowStyle$
  None=�5   	    � Title$ pRATER��5	   	    � 
ResizeMode$ NoResize=�6   $��546.818��6.   $��985.455��6?    � Icon$ images/logoicon.png��6O    � 	Resources 5         ButtonStyle1 �� 
TargetType �� Property �� Value �� 
TargetType	 ��Name
 J� SnapsToDevicePixels ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	        �� 5   
   " ��6%   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $	 border��6!   #��z��61   #��z��6]   #��z��6�   
 . ._�5      �� $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. #
 z
 6�   #��z��6  5       5      P� 5       �@��IsDefaulted . . �5   "   �� $ border��6@   # � ��6T    � ��5      P� 5       �@J�IsMouseOver . . �5   "   �� $ border��6?    � �� �#9494946S   5      P� 5       � �� . . �5   "   �� $ border��6?    � �� �#BDC3C76S   5      5      5!      5"      5#      .��5%      � .+�5'   
   � $
��Left=�6   $	��550��6*   $	��Top=�67   $	��180��6O   $��0,0,0,-3q�6[   ���#333.+�5(      �� -   5         ��Name$ txtName��5(      $
��Left=�6)   $��63,8,0,0q�6D   $
��Wrap=�6V   $��pRATER��6j   $	��Top=�6x   
�������$��Century Gothic)�6�   $��26.667(�6�   6�   �� 5)      -   5         ��Name$ imgLogo��5)      $
��Left=�6%   $��31��6@   $��	13,11,0,0q�6L   $	��Top=�6_   $��31��6w   $��images/logoicon.png��6�   �� 5*      -   5         ��Name$ btnHome��5*      $
��Home��6&   $
��Left=�65   $��	0,100,0,0q�6P   $	��Top=�6c   $	��180��6{   $��55��6�   $��21.333(�6�   $��Century Gothic)�6�   
�������#���   6  ��6�   Z� ��6�   Z� 6(  �� 5+      -   5        $ imgHome��5+      $
��Left=�6%   $��31��6@   $��
13,112,0,0q�6L   $	��Top=�6`   $��31��6x   $��images/homeicon.png��6�   �� 5,      -   5        $ 	btnBrowse��5,      $��Browse��6(   $
��Left=�69   $��	0,157,0,0q�6T   $	��Top=�6g   $	��180��6   $��55��6�   $��21.333(�6�   $��Century Gothic)�6�   
�������#���   6  ��6�   Z� ��6�   Z� 6,  �� 5-      -   5        $ 	imgBrowse��5-      $
��Left=�6'   $��32��6B   $��
13,169,0,0q�6N   $	��Top=�6b   $��31��6z   $��images/browseicon.png��6�   �� 5.      -   5        $ btnRate��5.      $
��Rate��6&   $
��Left=�65   $��	0,214,0,0q�6P   $	��Top=�6c   $	��180��6{   $��55��6�   $��21.333(�6�   $��Century Gothic)�6�   
�������#���   6  ��6�   Z� ��6�   Z� 6(  �� 5/      -   5        $ imgRate��5/      $
��Left=�6%   $��31��6@   $��
13,227,0,0q�6L   $	��Top=�6`   $��31��6x   $��images/rateicon.png��6�   �� 50      -	   5        $ btnAdmininster��50      $��Admin��6-   $y�Hidden=�6=   $
��Left=�6Q   $��	0,271,0,0q�6l   $	��Top=�6   $	��180��6�   $��55��6�   $��21.333(�6�   $��Century Gothic)�6�   
�������#���   6  ��6�   Z� ��6  Z� 6D  �� 51      -
   5        $ imgAdmin��51      $y�Hidden=�6&   $
��Left=�6:   $��31��6U   $��
13,284,0,0q�6a   $	��Top=�6u   $��31��6�   $��images/admin.png��6�   �� 52      -   5        $ imgNHTI��52      $
��Left=�6%   $��69��6@   $��
10,476,0,0q�6L   $	��Top=�6`   $	��160��6x   $��images/nhti-logo.png��6�   6�   53      � 57   
   -   5        $
��Left=�57      $��49��6*   $��180,-1,-1,0q�66   $	��Top=�6K   $	��805��6c   ���#990033.+�58      �� -   5        $ txtTab��58      $
��Left=�6(   $��10,8,0,0q�6C   $
��Wrap=�6U   $
��Home��6i   $	��Top=�6u   
�������$��Century Gothic)�6�   $��26.667(�6�   �� 59      -   5        $ imgSettings��59      $
��Left=�6*   $��25��6E   $��
685,13,0,0q�6Q   $	��Top=�6e   $��25��6}   
������ #���   6�   ��5:      �� 5;       �� ImageSource$ images/settings.png��6!   5=      �� 5>      -   5        $ btnMinimize��5>      $��_��6*   $
��Left=�66   $��	715,6,0,0q�6Q   $	��Top=�6d   $��36��6|   $��35��6�   $��21.333(�6�   $��Century Gothic)�6�   
�������#���   6  ��6�   Z� ��6�   Z� 6  �� 5?      -   5        $ btnClose��5?      $��X��6'   $
��Left=�63   $��	753,7,0,0q�6N   $	��Top=�6a   $��36��6y   $��35��6�   $��21.333(�6�   $��Century Gothic)�6�   
�������#���   6  ��6�   Z� ��6�   Z� 6  5@      � 5B   
   -   5         �Name$ gridSettings��5B      $��860,48,0,429q�6%   $y�Hidden=�6;    K� ZIndex$
 1000��6O   
�������.+�5C      �� -   5        $ btnAdmin��5C      $��Admin Login��6'   $
��Left=�6>   $	��Top=�6Y   $	��127��6q   $��37��6}   $��15(�6�   $��Century Gothic)�6�   
���   �#���   6�   $��	-1,-1,0,0q�6  ��6�   Z� ��6�   Z� 6-  �� 5D      -   5        $ btnDev��5D      $��	Developer��6%   $
��Left=�6:   $	��Top=�6U   $	��127��6m   $��35��6y   $��15(�6�   $��Century Gothic)�6�   
���   �#���   6�   $��
-1,36,-1,0q�6  ��6�   Z� ��6�   Z� 6*  5E       � 5H   
   -   5          �Name$ 	pageFrame��5H      $	��499��6#   $	��805��60   $��
180,48,0,0q�6<     � NavigationUIVisibility$ Hidden=�6P   6�   5J      5K      