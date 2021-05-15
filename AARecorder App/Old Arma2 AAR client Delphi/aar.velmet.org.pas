unit aar.velmet.org;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ShellAPI, Registry;

type
//TODO: No form file (DFM missing). Create a new DFM file using that https://stackoverflow.com/questions/6200163/delphi-dfm-not-found
  TAAR_client = class(TForm)
    Console: TMemo;
    Button1: TButton;
    Button2: TButton;
    cline: TEdit;
    Button3: TButton;
    Status: TEdit;
    Datam: TMemo;
    GroupBox1: TGroupBox;
    GroupBox2: TGroupBox;
    GroupBox3: TGroupBox;
    Button4: TButton;
    Button5: TButton;
    procedure FormShow(Sender: TObject);
    procedure WritePipe(thePipe: THandle; Buffer: string);
    procedure ReadPipe(thePipe: THandle);
    procedure ReadArmaComPipe(nullka: string);
        procedure WriteDelphiComPipe(Buffer: string);
        procedure ReadReplay;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
  private
    { Private declarations }
      armaData: THandle;
      delphiData: THandle;

      armaCom: THandle;
      delphiCom: THandle;
    procedure WriteReplay(nullka2: string);
  public
    { Public declarations }
  end;
   type TAARThread = class(TThread)
   private
   protected
     procedure Execute; override;
   end;
var
  AAR_client: TAAR_client;
     AAR: TAARThread;
     today: TDateTime;
implementation

{$R *.dfm}

function BrowseURL(const URL: string): boolean;
var
   Browser: string;
begin
   Result := True;
   Browser := '';
   with TRegistry.Create do
      try
         RootKey := HKEY_CLASSES_ROOT;
      Access := KEY_QUERY_VALUE;
      if OpenKey('\htmlfile\shell\open\command', False) then
         Browser := ReadString('');
      CloseKey;
   finally
      Free;
   end;
   if Browser = '' then
   begin
      Result := False;
      Exit;
   end;
   Browser := Copy(Browser, Pos('"', Browser) + 1, Length(Browser));
   Browser := Copy(Browser, 1, Pos('"', Browser) - 1);
   //   ShellExecute(0, 'open', PChar(Browser), PChar(URL), nil, SW_SHOW) ;
   ShellExecute(0, 'open', PChar(URL), nil, nil, SW_SHOW);
end;

procedure TAAR_client.WriteReplay(nullka2: string);
var
   avail,
   remain,
   read: Cardinal;
   Buffer: String;
   replay: TextFile;
   cdate: String;

begin
  sleep(50);
   if (Status.Text='RECORDING') then
   begin
      Console.Lines.Add('Waiting for data');
      cdate := FormatDateTime('yyyymmdd-hhnnss', Now);
      //AssignFile(replay, cdate + '.aar');
Console.Lines.Add('raplay file created and prepared');
        AssignFile(replay,'test.aar');
      ReWrite(replay);
      Buffer := 'empte';

      while (Status.Text = 'RECORDING')  do
      begin
Datam.Lines.Add('Reading armaCom');
ReadArmaComPipe('null');
//sleep(1000);
         if not PeekNamedPipe(armaData, nil, 0, nil, @avail, @remain) then
         begin
Datam.Lines.Add('Arma is not available');
//sleep(1000);
         end
         else
         begin
            if (remain <= 0) then
            begin
             Console.Lines.Add('Arma connected. Waiting for data...');
//sleep(1000);
            end
            else
            begin
               {    Reset(myFile);

               // Display the file contents
               while not Eof(myFile) do
               begin
               ReadLn(myFile, text);
               ShowMessage(text);
               end;}
               Datam.Lines.Add('Reading');
               SetLength(Buffer, remain);
               ZeroMemory(@Buffer[1], remain);
               ReadFile(armaData, Buffer[1], remain, read, nil);
              // Datam.Lines.Add('Read: ' + InttoStr(read) + '/' + InttoStr(remain));
               Datam.Lines.Add(Buffer);
               WriteLn(replay, Buffer);
            end;
         end;
      end;
      Console.Lines.Add('No data. Exiting.');
      CloseFile(replay);
      Console.Lines.Add('test.aar saved. Standing by.');
      //Console.Lines.Add('File ' + cdate + '.txt saved. Stopped!');

   end
   else
begin Console.Lines.Add('Record mode off') end;
end;

procedure TAAR_client.FormShow(Sender: TObject);
const
  OpenMode = PIPE_ACCESS_DUPLEX or FILE_FLAG_OVERLAPPED;
  PipeMode = PIPE_TYPE_MESSAGE or PIPE_READMODE_MESSAGE or PIPE_WAIT;
  Instances = PIPE_UNLIMITED_INSTANCES;
begin
Console.Lines.Add('OK: Starting thread');
AAR := TAARThread.Create(False);
AAR.Priority := tpLowest;

delphiCom := CreateNamedPipe(
   PChar('\\.\pipe\delphiCom'), OpenMode, PipeMode,
    Instances,
   1024,
   1024,
   1000,
   nil);
   if delphiCom = INVALID_HANDLE_VALUE then
   begin
      Console.Lines.Add('No delphiCom pipe');

   end
   else
   begin
      Console.Lines.Add('OK: delphiCom opened')
   end;

     armaCom := CreateNamedPipe(
   PChar('\\.\pipe\armaCom'), OpenMode, PipeMode,
    Instances,
   1024,
   1024,
   1000,
   nil);
   if armaCom = INVALID_HANDLE_VALUE then
   begin
      Console.Lines.Add('No armaCom pipe');
   end
   else
   begin
      Console.Lines.Add('OK: armaCom opened')
   end;

delphiData := CreateNamedPipe(
   PChar('\\.\pipe\delphiData'), OpenMode, PipeMode,
    Instances,
   1024,
   1024,
   1000,
   nil);
   if delphiData = INVALID_HANDLE_VALUE then
   begin
      Console.Lines.Add('No delphiData pipe');

   end
   else
   begin
      Console.Lines.Add('OK: delphiData opened')
   end;

     armaData := CreateNamedPipe(
   PChar('\\.\pipe\armaData'), OpenMode, PipeMode,
    Instances,
   1024,
   1024,
   1000,
   nil);
   if armaData = INVALID_HANDLE_VALUE then
   begin
      Console.Lines.Add('No armaData pipe');
   end
   else
   begin
      Console.Lines.Add('OK: armaData opened')
   end;
end;

procedure TAAR_client.ReadPipe(thePipe: THandle);
var
   avail,
   remain,
   read: Cardinal;
   Buffer: String;
begin
if not PeekNamedPipe(thePipe, nil, 0, nil, @avail, @remain) then
   begin
      Console.Lines.Add('No pipe');
   end
   else
   begin
      if (remain <= 0) then
      begin
         Console.Lines.Add('OK: Pipe is empty');
      end
      else
      begin

         SetLength(Buffer, remain);
         ZeroMemory(@Buffer[1], remain);
         ReadFile(thePipe, Buffer[1], remain, read, nil);

         //  Console.Lines.Add('Read: ' + InttoStr(read) + '/' + InttoStr(remain));
         Console.Lines.Add('PIPE SAYS: ' + Buffer);
          //Status.Text := Buffer;
         // Sleep(2000);
       end;
   end;
end;

procedure TAAR_client.ReadArmaComPipe(nullka: string);
var
     thePipe: THandle;
   avail,
   remain,
   read: Cardinal;
   Buffer: String;
   once, once1: Boolean;
begin
once := true;
once1 := true;
thePipe := armaCom;
if not PeekNamedPipe(thePipe, nil, 0, nil, @avail, @remain) then
   begin
              if(once1) then begin
      Console.Lines.Add('No compipe');
       once1:=false;
      end;
   end
   else
   begin
      if (remain <= 0) then
      begin
           if(once) then begin
           Console.Lines.Add('OK: Com pipe is empty');
           once:=false;
           end;
      end
      else
      begin

         SetLength(Buffer, remain);
         ZeroMemory(@Buffer[1], remain);
         ReadFile(thePipe, Buffer[1], remain, read, nil);

         //  Console.Lines.Add('Read: ' + InttoStr(read) + '/' + InttoStr(remain));
         //Console.Lines.Add('COM PIPE SAYS: ' + Buffer);
          if (Buffer = 'OFF') then begin
//                AAR.Terminate;
Close;
          end;
          Status.Text := Buffer;
         // Sleep(2000);
          

      end;
   end;
end;

procedure TAAR_client.WritePipe(thePipe: THandle; Buffer: string);
var
   read: Cardinal;

begin
   //write
   //Buffer := 'SERVER ACTIVE';
   WriteFile(thePipe, Buffer[1], Length(Buffer) * SizeOf(Char)+1, read, nil);
   if read <> Length(Buffer) * SizeOf(Char)+1 then
   begin
      Console.Lines.Add('Failed to write the data thePipe');
   end
   else
   begin
      Console.Lines.Add(Buffer + ' sent to the pipe');
   end;

end;

procedure TAAR_client.WriteDelphiComPipe(Buffer: string);
var
   read: Cardinal;
thePipe: THandle;
begin
thePipe := delphiCom;
   //write
   //Buffer := 'SERVER ACTIVE';
   WriteFile(thePipe, Buffer[1], Length(Buffer) * SizeOf(Char) + 1, read, nil);
   if read <> Length(Buffer) * SizeOf(Char) + 1 then
   begin
      Console.Lines.Add('Failed to write the data thePipe');
   end
   else
   begin
      Console.Lines.Add(Buffer + ' sent to the pipe');
   end;

end;

procedure TAAR_client.ReadReplay;
var
   read: Cardinal;
   stime: string;
   replay: TextFile;
   wBuffer: string ;
begin
      //cdate := FormatDateTime('yyyymmdd-hhnnss', Now);

      Console.Lines.Add('Opening file');

      AssignFile(replay, 'test.aar');
      Reset(replay);
      Console.Lines.Add('Starting playback');
      while (Status.Text = 'PLAYBACK') do begin
ReadArmaComPipe('null');
today := Time;
stime := DateTimeToStr(today);
//WBuffer:= stime;
if(Status.Text = 'PLAYBACK') then begin

   if(Eof(replay)) then begin
   AAR_client.WriteDelphiComPipe('EOF');
    break;
   end;
   ReadLn(replay, wBuffer);
   WriteFile(delphiData, wBuffer[1], Length(wBuffer) * SizeOf(Char) + 1, read, nil);
   if read <> Length(wBuffer) * SizeOf(Char) + 1 then
   begin
      Console.Lines.Add('Failed to write the data thePipe');
   end
   else
   begin
      Datam.Lines.Add(wBuffer + ' sent to the pipe :');
   end;
end else begin
   Console.Lines.Add('Waiting For Arma ready');
              Console.Lines.Add('Stop received');
//           AAR_client.WriteDelphiComPipe('EOF');
           break;

   end;
Sleep(1);

           end;

           //end while
           CloseFile(replay);
           //WT.Terminate ;
end;

procedure TAARThread.Execute;
var
mafile: string;
sometrue: Boolean;
aarCommand: string;
begin
AAR_client.Console.Lines.Add('OK: Main thread started');
while(sometrue) do begin
AAR_client.ReadArmaComPipe('null');
aarCommand := AAR_client.Status.Text;
    if(aarCommand = 'RECORDING') then begin
    AAR_client.Console.Lines.Add('Recording Now');
    AAR_client.WriteDelphiComPipe('ROGER_RECORDING');
      AAR_client.WriteReplay('blah');
    end;

    if(aarCommand = 'PLAYBACK') then begin
    AAR_client.Console.Lines.Add('Replaying Now') ;
    AAR_client.WriteDelphiComPipe('ROGER_PLAYBACK');
      AAR_client.ReadReplay;
    end;
sleep(1000);
  end;
end;

procedure TAAR_client.Button1Click(Sender: TObject);
begin
WritePipe(armaCom, Cline.Text);
end;

procedure TAAR_client.Button2Click(Sender: TObject);
begin
ReadPipe(armaCom);
end;

procedure TAAR_client.Button3Click(Sender: TObject);
begin
ReadPipe(armaData);
end;

procedure TAAR_client.FormClose(Sender: TObject; var Action: TCloseAction);
begin
AAR.Terminate;
end;

procedure TAAR_client.Button4Click(Sender: TObject);
begin
   BrowseURL('http://dev-heaven.net/projects/a2aar');
end;

procedure TAAR_client.Button5Click(Sender: TObject);
begin
  BrowseURL('http://dev-heaven.net/projects/a2aar/wiki');
end;

end.
