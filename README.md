# Virus
I spent about 3 days putting this together, and it has tons of features.

The first thing that it does when executed it adds itself to registry.
Then it makes itself an protected process.

Then it will implement its ring3 rootkit. (Blocks TaskManager)
Constantly checks for new drivers to spread by USB.
It also spreads itself by emailing itself.

It has over 30 anti-debugging processes.
Here is the list:
Anti-Notepad
Anti-CMD
Anti-Outpost
Anti-Node32
Anti-ZoneAlarm
Anti-VMWare
Anti-KAV
Anti-VirtualBox
Anti-VirtualPC
Anti-Anubis Method 1
Anti-Anubis Method 2
Anti-WireShark
Anti-WindowsDefender
Anti-ASquared
Anti-Avast
Anti-AVG
Anti-Bitdefender
Anti-Kaspersky
Anti-MalwareBytes
Anti-McAfee
Anti-Nod32 Method 2
Anti-Norton
Anti-OllyDebugger
Anti-IDDT
Anti-AQtime Method 1
Anti-AQtime Method 2
Anti-PROA
Anti-WinDbg
Anti-ConEmu
Anti-ColorConsole
Anti-PowerCMD
Anti-Sandboxie



It also disables registry editor, and firewall.

It also blocks the url: taskmanagerfix.com in 3 different ways. 
- blocks direct ip
- blocks url with http://
- blocks url without http://

It makes the forms used for virus hidden and not show up in taskbar.

The payload that I implemented was a keylogger that emails log files to you

Overall I would say that getting rid of this trojan/virus is impossible until AV can detect it, but as of 11/16/18 it is still completely FUD.
USE: https://nodistribute.com/ - Use VPN when out of uses, or spoof IP.
