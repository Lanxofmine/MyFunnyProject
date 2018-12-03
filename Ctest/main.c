#include<stdio.h>
#include<stdlib.h>
#include<MessagesDescriptor.pb.h>
#include<Messages.pb.h>
#include <string.h>
#include <pb_encode.h>
#include <pb_decode.h>
#include <reads.h>
#include <writes.h>

#if defined(MSDOS) || defined(OS2) || defined(WIN32) || defined(__CYGWIN__)
#  include <fcntl.h>
#  include <io.h>
#  define SET_BINARY_MODE(file) setmode(fileno(file), O_BINARY)
#else
#  define SET_BINARY_MODE(file)
#endif

#if defined(MSDOS) || defined(OS2) || defined(WIN32) || defined(__CYGWIN__)
#  include <fcntl.h>
#  include <io.h>
#  define SET_BINARY_MODE(file) setmode(fileno(file), O_BINARY)
#else
#  define SET_BINARY_MODE(file)
#endif

int regReqEnc() {
	proto_SelfDescribingMessage msgtotal = proto_SelfDescribingMessage_init_zero;
	//msgtotal.message_method = proto_SelfDescribingMessage_MessageMethod_DeviceRegister;
	msgtotal.message_method = proto_SelfDescribingMessage_MessageMethod_MessageNumberQuery;
	msgtotal.protocol_method = proto_SelfDescribingMessage_ProtocolMethod_Request;

	msgtotal.which_message = proto_SelfDescribingMessage_deviceRegisterRequest_tag;
	//msgtotal.message.deviceRegisterRequest.lock_no.funcs.encode = &write_submsg;
	//msgtotal.message.deviceRegisterRequest.lock_no.arg = "lock_no_1";
	//msgtotal.message.deviceRegisterRequest.security_code.encryption_algorithm.funcs.encode = &write_fixed32;
	//msgtotal.message.deviceRegisterRequest.security_code.encryption_algorithm.arg = 0;
	//msgtotal.message.deviceRegisterRequest.security_code.security_code.funcs.encode = &write_submsg;
	//msgtotal.message.deviceRegisterRequest.security_code.security_code.arg = ;

	//proto_SecurityCode scode =

	uint8_t buffer[64];
	pb_ostream_t stream;

	proto_DeviceRegisterRequest msgDevReg = proto_DeviceRegisterRequest_init_zero;
	msgDevReg.lock_no.funcs.encode = &write_string;
	msgDevReg.lock_no.arg = "yunlock001";  /*锁的编号，后面会需要按配置的参数来*/

	proto_SecurityCode scode = proto_SecurityCode_init_default;
	scode.encryption_algorithm = 0;
	scode.security_code.funcs.encode = &write_string;
	scode.security_code.arg = "security_code";
	//scode.security_code.funcs.encode = &write_string;
	//scode.security_code.arg = "security_code";
	msgDevReg.security_code = scode;
	msgtotal.message.deviceRegisterRequest = msgDevReg;

	stream = pb_ostream_from_buffer(buffer, sizeof(buffer));
	//pb_encode_delimited(&stream, proto_SelfDescribingMessage_fields, &msgtotal);
	//bodylen = stream.bytes_written;
	if (pb_encode_delimited(&stream, proto_SelfDescribingMessage_fields, &msgtotal))
	{
		int num = stream.bytes_written;
		puts("\nString start");
		SET_BINARY_MODE(stdout);
		fwrite(buffer, 1, stream.bytes_written, stdout);
		puts("\nString over");
		puts("\n");
		puts("\nHex start");
		int i;
		for (i = 0;i < num; i++)
		{
			printf("%x ", buffer[i]);
		}
		//return 0; /* Success */
	}
	else
	{
		fprintf(stderr, "Encoding failed: %s\n", PB_GET_ERROR(&stream));
		//return 1; /* Failure */
	}

	puts("\nHex over");

	return 0;
}


int regResDec() {
	//21 10 1 22 1d a a 79 75 6e 6c 6f 63 6b 30 30 31 12 f 12 d 73 65 63 75 72 69 74 79 5f 63 6f 64 65
	uint8_t buffer[34] = { 0x21,0x10,0x1,0x22,0x1d,0xa,0xa,0x79,0x75,0x6e,0x6c,0x6f,0x63,0x6b,0x30,0x30,0x31,0x12,0xf,0x12,0xd,0x73,0x65,0x63,0x75,0x72,0x69,0x74,0x79,0x5f,0x63,0x6f,0x64,0x65 };
	size_t count = 34;
	pb_istream_t stream;
	stream = pb_istream_from_buffer(buffer, count);
	proto_SelfDescribingMessage msgtotal; //= proto_SelfDescribingMessage_init_zero;

	msgtotal.message.deviceRegisterRequest.lock_no.funcs.decode = &read_string;
	msgtotal.message.deviceRegisterRequest.lock_no.arg = "1014";

	/* Fill with garbage to better detect initialization errors */
	memset(&msgtotal, 0xAA, sizeof(msgtotal));

	if (pb_decode_delimited(&stream, proto_SelfDescribingMessage_fields, &msgtotal))
	{
		puts("\nDecode success.");

		//return 0; /* Success */
	}
	else
	{
		fprintf(stderr, "Decoding failed: %s\n", PB_GET_ERROR(&stream));
		//return 1; /* Failure */
	}

	puts("\nHex over");

	return 0;
}


int main()
{
	regReqEnc();
	regResDec();
	system("pause");
	return 0;
}