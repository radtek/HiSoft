﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace 来电提醒客户端
{
    public class Phone
    {
        //通道
        public int Channel { get; set; } = 0;

        //通道名称
        public string ChannelName { get; set; } = "";

        //设备码
        public string DeviceCode { get; set; } = "";

        //设备状态
        public string DeviceInfo { get; set; } = "";


        //线路状态
        public string LineState { get; set; }

        //呼入号码
        public string CallerID { get; set; }
        //播出号码
        public string DialedNum { get; set; }

        private string Number { get; set; }
        public string ComName { get { return SetConfig.ComName(Number); } set { if (Number != value) { Number = value; } } }

        //漏接电话
        public string MissedCall { get; set; }

        //通话时间
        public string TalkTime { get; set; }
        public DateTime time1 { get; set; }
        public DateTime time2 { get; set; }


        public bool bChannelState;
        public bool bRecord;
        public bool bDevicePlay;
        public bool bLinePlay;
        public bool bMonitor;
        public bool bLineBusy;
        public bool bDisableRinging;
        public bool bDisconnectPhone;
        public bool bAutodial;
        public bool bHookOff;
        public int iDeviceType;

        public Phone(int _Channel)
        {
            Channel = _Channel;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Device
    {
        public const int DEVICE_AD130 = 1;
        public const int DEVICE_AD230 = 2;
        public const int DEVICE_AD430 = 3;

        public const int MAX_DEVICE = 0x04;


        public const int MCU_BACKSTATE = 0x08;		// Return channel State
        public const int MCU_BACKCID = 0x09;		// Return CallerID
        public const int MCU_BACKDIGIT = 0x0A;		// Return Dial Digit
        public const int MCU_BACKPARAM = 0x0C;		// Return Paramter
        public const int MCU_BACKCPUVER = 0x0D;		// Return CPU version
        public const int MCU_BACKCOLLATERAL = 0x0E;	// Return Collateral phone dialed
        public const int MCU_BUSYTONE = 0x0F;		// Return detect line busy tone
        public const int MCU_PLAYVOLUME = 0X10;     // Return volume value of playback
        public const int MCU_RECORDLVOLUME = 0X11;  // Return left volume value of record
        public const int MCU_RECORDRVOLUME = 0X12;  // Return right volume value of record
        public const int MCU_LINEMODE = 0X13;       // Return line voltage mode
        public const int MCU_DEVICECODE = 0X14;     // Return device code
        public const int MCU_MICPARAM = 0X15;       // Return MIC trigger param
        public const int MCU_EARPARAM = 0X16;       // Return EAR trigger param
        public const int MCU_TIMEOUTPARAM = 0X17;   // Return Timeout param
        public const int MCU_MICTRIGGERED = 0X18;   // Return MIC triggered state
        public const int MCU_EARTRIGGERED = 0X19;   // Return EAR triggered state
        public const int MCU_SWPLAYVOLUME = 0X20;	// Return software boosted playback volume
        public const int MCU_SWRECVOLUME = 0X21;	// Return software boosted recording volume

        public const int MCU_BACKDISABLE = 0xFF;		// Return Device is disabled
        public const int MCU_BACKENABLE = 0xEE;		// Return Device is enabled
        public const int MCU_BACKMISSED = 0xAA;		// Return Missed call 
        public const int MCU_BACKTALK = 0xBB;		// Return talk time
        public const int MCU_PLAYOVER = 0xCC;     // Return play sound over


        public const int HOOKON_POSITIVEPOLARITY = 0x01; // Phone hook on with positive polarity
        public const int HOOKON_NEGATIVEPOLARITY = 0x02;	// Phone hook on with negative polarity
        public const int HAVE_POLARITY = 0x03;	// Line have polarity 
        public const int HOOKOFF_POSITIVEPOLARITY = 0x04;	// Phone hook off with positive polarity
        public const int HOOKOFF_NEGATIVEPOLARITY = 0x05;	// Phone hook off with negative polarity
        public const int NOLINE_NOPOLARITY = 0x06; // No line with no polarity
        public const int RINGON = 0x07;	// Phone ring on
        public const int RINGOFF = 0x08;	// Phone ring off 
        public const int NOHOOK_POSITIVEPOLARITY = 0x09; // No hook(doesn't operate phone) with positive polarity
        public const int NOHOOK_NEGATIVEPOLARITY = 0x0A;	// No hook(doesn't operate phone) with negative polarity
        public const int NOHOOK_NOPOLARITY = 0x0B;	// No hook(doesn't operate phone) with no polarity

        public const int CHANNE_LINEBUSY = 0x00;		// Make line of specified channel to busy
        public const int CHANNEL_LINEFREE = 0x01;		// Make line of specified channel to free
        public const int CHANNEL_CONNECTPHONE = 0x02;		// Make line of specified to connect with phone
        public const int CHANNEL_DISCONNECTPHONE = 0x03;		// Make line of specified to disconnect with phone

        public const int CLEAR_CALLERID = 0x00;	// clear caler id 
        public const int CLEAR_DILAEDNUM = 0x01;	// clear dialed number
        public const int CLEAR_RINGCOUNT = 0x02;	// clear ring count
        public const int CLEAR_TALKTIME = 0x03;	// clear talk time

        public const int DEVICE_PLAY = 0x00;	// use AD130 deivce to play sound
        public const int LINE_PLAY = 0x01;	// play sound to line(the other side can hear the sound played);

        public const int VOLUME_PLAY = 0X00;	// volume for device plays sound
        public const int VOLUME_RECORDLINE = 0X01; // line mode, volume for device records
        public const int VOLUME_RECORDEAR = 0X02; // handset mode, Ear volume for device records
        public const int VOLUME_RECORDMIC = 0X03; // handset mode, Mic volume for device records


        public const int LINEMODE_24V = 0X24; // line voltage is 24v mode
        public const int LINEMODE_48V = 0X48; // line voltage is 48v mode




        public const int COLUMN_CHANNELNO = 0;
        public const int COLUMN_CHANNELSTATE = 1;
        public const int COLUMN_LINESTATE = 2;
        public const int COLUMN_CALLERID = 3;
        public const int COLUMN_DIALEDNUM = 4;
        public const int COLUMN_TALKTIME = 5;
        public const int COLUMN_CPUVER = 6;
        public const int COLUMN_DEVICECODE = 7;

        public const int WM_AD130MSG = 1024 + 220;



        [DllImport("AD130Device.dll", EntryPoint = "AD130_InitDevice")]
        public static extern int InitDevice(int hWnd);

        // Free devices 

        [DllImport("AD130Device.dll", EntryPoint = "AD130_FreeDevice")]
        public static extern void FreeDevice();


        [DllImport("AD130Device.dll", EntryPoint = "AD130_ChangeWindowHandle")]
        public static extern void ChangeWindowHandle(int hWnd);

        [DllImport("AD130Device.dll", EntryPoint = "AD130_GetCurDevCount")]
        public static extern int GetCurDevCount();

        [DllImport("AD130Device.dll", EntryPoint = "AD130_GetDeviceMicrophoneName")]
        public static extern int GetDeviceMicrophoneName(int dwChannel, StringBuilder szMicrophoneName);

        [DllImport("AD130Device.dll", EntryPoint = "AD130_GetDeviceSpeakerName")]
        public static extern int GetDeviceSpeakerName(int dwChannel, StringBuilder szSpeakerName);

        [DllImport("AD130Device.dll", EntryPoint = "AD130_SetLineMode")]
        public static extern int SetLineMode(int dwChannel, int enumLineMode);

        [DllImport("AD130Device.dll", EntryPoint = "AD130_ReadLineMode")]
        public static extern int ReadLineMode(int dwChannel);

        [DllImport("AD130Device.dll", EntryPoint = "AD130_GetDeviceType")]
        public static extern int GetDeviceType(int dwChannel);



        [DllImport("AD130Device.dll", EntryPoint = "AD130_GetParameter")]
        public static extern void GetParameter(int dwChannel, ref AD130DEVICEPARAMETER tagParameter);

        [DllImport("AD130Device.dll", EntryPoint = "AD130_ReadParameter")]
        public static extern void ReadParameter(int dwChannel);

        // Set systematic parameter  
        [DllImport("AD130Device.dll", EntryPoint = "AD130_SetParameter")]
        public static extern int SetParameter(int dwChannel, ref AD130DEVICEPARAMETER tagParameter);


        // Get caller id number  
        [DllImport("AD130Device.dll", EntryPoint = "AD130_GetCallerID", CharSet = CharSet.Ansi)]
        public static extern int GetCallerID(int dwChannel, StringBuilder szCallerIDBuffer);

        // Get dialed number 
        [DllImport("AD130Device.dll", EntryPoint = "AD130_GetDialDigit", CharSet = CharSet.Ansi)]
        public static extern int GetDialDigit(int dwChannel, StringBuilder szDialDigitBuffer);


        [DllImport("AD130Device.dll", EntryPoint = "AD130_GetState")]
        public static extern int GetState(int dwChannel);


        // Get ring count
        [DllImport("AD130Device.dll", EntryPoint = "AD130_GetRingCount")]
        public static extern int GetRingCount(int dwChannel);

        // Get talking time
        [DllImport("AD130Device.dll", EntryPoint = "AD130_GetTalkTime")]
        public static extern int GetTalkTime(int dwChannel);


        [DllImport("AD130Device.dll", EntryPoint = "AD130_GetCPUVersion", CharSet = CharSet.Ansi)]
        public static extern int GetCPUVersion(int dwChannel, StringBuilder szCPUVersion);

        // Clear some buffer( e.g. caller id, dialed number, ring count, talk time) 
        [DllImport("AD130Device.dll", EntryPoint = "AD130_Clear")]
        public static extern void Clear(int dwChannel, int enumClear);


        // Set the phone to enable ringing or disable ringing 
        [DllImport("AD130Device.dll", EntryPoint = "AD130_SetRinging")]
        public static extern int SetRinging(int dwChannel, int bEnableRinging);

        // Set line to busy, free, connect with phone or disconnect with phone
        [DllImport("AD130Device.dll", EntryPoint = "AD130_SetLine")]
        public static extern int SetLine(int dwChannel, int enumLineSetting);

        // Set Channel to start talking then start timer
        // After you picked up phone, if you want to SDK start calculating talk time just call this function.
        [DllImport("AD130Device.dll", EntryPoint = "AD130_StartCalculatingTalkTime")]
        public static extern void StartCalculatingTalkTime(int dwChannel);



        // Set time to start talking after dialed number 
        // After you dial a number if you do nothing rather than this time, SDK will start calculating talk time 
        [DllImport("AD130Device.dll", EntryPoint = "AD130_SetTimeToStartCalculatingTalkTime")]
        public static extern void SetTimeToStartCalculatingTalkTime(int nSecond);


        // Set time to judge missed call, when received caller id or ringing you don't pick up phone rather than this time
        // so this call was missed call.
        [DllImport("AD130Device.dll", EntryPoint = "AD130_SetMissedCallParam")]
        public static extern void SetMissedCallParam(int nSecond);




        // Start monitor
        [DllImport("AD130Device.dll", EntryPoint = "AD130_StartMonitor")]
        public static extern int StartMonitor(int dwChannel);

        // Stop monitor
        [DllImport("AD130Device.dll", EntryPoint = "AD130_StopMonitor")]
        public static extern int StopMonitor(int dwChannel);



        // Enable/disalbe device or line play file 
        [DllImport("AD130Device.dll", EntryPoint = "AD130_EnablePlayFile")]
        public static extern int EnablePlayFile(int dwChannel, int enumPlay, int bEnable);

        // Start play file 
        [DllImport("AD130Device.dll", EntryPoint = "AD130_StartPlayFile")]
        public static extern int StartPlayFile(int dwChannel, int enumPlay, char[] pszFile);

        // Stop play file
        [DllImport("AD130Device.dll", EntryPoint = "AD130_StopPlayFile")]
        public static extern int StopPlayFile(int dwChannel, int enumPlay);

        // Start recording 
        [DllImport("AD130Device.dll", EntryPoint = "AD130_StartRecordFile")]
        public static extern int StartRecordFile(int dwChannel, char[] pszFile);

        // Stop recording  
        [DllImport("AD130Device.dll", EntryPoint = "AD130_StopRecordFile")]
        public static extern int StopRecordFile(int dwChannel);



        // Pick up phone
        [DllImport("AD130Device.dll", EntryPoint = "AD130_PickupPhone")]
        public static extern int PickupPhone(int dwChannel);

        // Hang up phone, just can hang up phone that you picked up phone via call the function AD130_PickupPhone 
        [DllImport("AD130Device.dll", EntryPoint = "AD130_HangupPhone")]
        public static extern int HangupPhone(int dwChannel);
    }
}
