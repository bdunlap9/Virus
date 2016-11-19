# Virus
I spent about 3 days putting this together, and it has tons of features.

The first thing that it does when executed it adds itself to registry.
Then it makes itself an protected process.

Then it will implement its ring3 rootkit. (Blocks TaskManager)
Constantly checks for new drivers to spread by USB.
It also spreads itself by emailing itself.

It has over 30 anti-debugging processes.
Here is the list:
1.   Anti-Notepad
2.   Anti-CMD
3.   Anti-Outpost
4.   Anti-Node32
5.   Anti-ZoneAlarm
6.   Anti-VMWare
7.   Anti-KAV
8.   Anti-VirtualBox
9.   Anti-VirtualPC
10.  Anti-Anubis Method 1
11.  Anti-Anubis Method 2
12.  Anti-WireShark
13.  Anti-WindowsDefender
14.  Anti-ASquared
15.  Anti-Avast
16.  Anti-AVG
17.  Anti-Bitdefender
18.  Anti-Kaspersky
19.  Anti-MalwareBytes
20.  Anti-McAfee
21.  Anti-Nod32 Method 2
22.  Anti-Norton
23.  Anti-OllyDebugger
24.  Anti-IDDT
25.  Anti-AQtime Method 1
26.  Anti-AQtime Method 2
27.  Anti-PROA
28.  Anti-WinDbg
29.  Anti-ConEmu
30.  Anti-ColorConsole
31.  Anti-PowerCMD
32.  Anti-Sandboxie



It also disables registry editor, and firewall.

It also blocks the url: taskmanagerfix.com in 3 different ways. 
- blocks direct ip
- blocks url with http://
- blocks url without http://

It makes the forms used for virus hidden and not show up in taskbar.

The payload that I implemented was a keylogger that emails log files to you

Overall I would say that getting rid of this trojan/virus is impossible until AV can detect it, but as of 11/15/16 it is still completely FUD.
USE: https://nodistribute.com/ - Use VPN when out of uses, or spoof IP.
