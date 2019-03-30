/* Title    : RC4Engine.cs
 * Author   : Simone Spagna
 * Purpose  : Encrypt/Decrypt strings using RC4 Alghoritm
 * */
using System;
using System.Globalization;
using System.Text;
using System.Collections;


namespace BusLib
{
	/// <summary>
	/// Summary description for RC4Engine.
	/// </summary>
	public class RC4Engine
	{
		#region Costructor

		public RC4Engine()
		{
		}

		#endregion

		#region Public Method

		/// <summary>
		/// Encript InClear Text using RC4 method using EncriptionKey
		/// Put the result into CryptedText 
		/// </summary>
		/// <returns>true if success, else false</returns>
		public static string Encrypt(string InputText,string Key)
        {
            m_sInClearText = InputText;
            EncryptionKey = Key;
			//
			// toRet is used to store function retcode
			//
		

			try
			{
				//
				// indexes used below
				//
				long i=0;
				long j=0;

				//
				// Put input string in temporary byte array
				//
				Encoding enc_default = Encoding.Default;
				byte[] input  = enc_default.GetBytes(m_sInClearText);
				
				// 
				// Output byte array
				//
				byte[] output = new byte[input.Length];
				
				//
				// Local copy of m_nBoxLen
				//
				byte[] n_LocBox = new byte[m_nBoxLen];
				m_nBox.CopyTo(n_LocBox,0);
				
				//
				//	Len of Chipher
				//
				long ChipherLen = input.Length + 1;

				//
				// Run Alghoritm
				//
				for ( long offset = 0; offset < input.Length ; offset++ )
				{
					i = ( i + 1 ) % m_nBoxLen;
					j = ( j + n_LocBox[i] ) %  m_nBoxLen; 
					byte temp =  n_LocBox[i];
					n_LocBox[i] = n_LocBox[j];
					n_LocBox[j] = temp;
					byte a = input[offset];
					byte b = n_LocBox[(n_LocBox[i]+n_LocBox[j])% m_nBoxLen];
					output[offset] = (byte)((int)a^(int)b);	
				}	
				
				//
				// Put result into output string ( CryptedText )
				//
				char[] outarrchar = new char[enc_default.GetCharCount(output,0,output.Length)];
				enc_default.GetChars(output,0,output.Length,outarrchar,0);
				m_sCryptedText = new string (outarrchar);
			}
			catch
			{
				//
				// error occured - set retcode to false.
				// 
                return "";

			}

			//
			// return retcode
			//
            return m_sCryptedText;

		}

		/// <summary>
		/// Decript CryptedText into InClearText using EncriptionKey
		/// </summary>
		/// <returns>true if success else false</returns>
        public static string Decrypt(string EncryptedText, string Key)
		{
			//
			// toRet is used to store function retcode
			//
			
			try
			{
			    m_sInClearText = Encrypt(EncryptedText, Key);
				
			}
			catch
			{
				//
				// error occured - set retcode to false.
				// 
                return "";
			}
			
            return m_sInClearText;
		}
		
		#endregion

		#region Prop definitions
		/// <summary>
		/// Get or set Encryption Key
		/// </summary>
		public static string EncryptionKey
		{
			get
			{
				return ( m_sEncryptionKey );
			}
			set
			{
				//
				// assign value only if it is a new value
				//
				//if ( m_sEncryptionKey != value )
				//{	
					m_sEncryptionKey = value;

					//
					// Used to populate m_nBox
					//
					long index2 = 0;

					//
					// Create two different encoding 
					//
					Encoding ascii		= Encoding.ASCII;
					Encoding unicode	= Encoding.Unicode;

					//
					// Perform the conversion of the encryption key from unicode to ansi
					//
					byte[] asciiBytes = Encoding.Convert(unicode,ascii,unicode.GetBytes(m_sEncryptionKey));

					//
					// Convert the new byte[] into a char[] and then to string
					//
					
					char[] asciiChars = new char[ascii.GetCharCount(asciiBytes,0,asciiBytes.Length)];
					ascii.GetChars(asciiBytes,0,asciiBytes.Length,asciiChars,0);
					m_sEncryptionKeyAscii = new string(asciiChars);

					//
					// Populate m_nBox
					//
					long KeyLen = m_sEncryptionKey.Length;
					
					//
					// First Loop
					//
                    m_nBox = new byte[m_nBoxLen];
					for ( long count = 0; count < m_nBoxLen ; count ++ )
					{
						m_nBox[count] = (byte)count;
					}
					
					//
					// Second Loop
					//
					for ( long count = 0; count < m_nBoxLen ; count ++ )
					{
						index2 = (index2 + m_nBox[count] + asciiChars[ count % KeyLen ]) % m_nBoxLen;
						byte temp		= m_nBox[count];
						m_nBox[count]	= m_nBox[index2];
						m_nBox[index2]	= temp;
					}

				//}
			}
		}

		public string InClearText
		{
			get
			{
				return ( m_sInClearText );
			}
			set
			{
				//
				// assign value only if it is a new value
				//
				if (m_sInClearText	!= value)
				{	
					m_sInClearText	= value;
				}
			}
		}

		public string CryptedText
		{
			get
			{
				return ( m_sCryptedText );
			}
			set
			{
				//
				// assign value only if it is a new value
				//
				if ( m_sCryptedText != value )
				{	
					m_sCryptedText = value;
				}
			}
		}
		#endregion

		#region Private Fields
		
		//
		// Encryption Key  - Unicode & Ascii version
		//
		private static string m_sEncryptionKey		 = "";
		private static string m_sEncryptionKeyAscii = "";
		//
		// It is related to Encryption Key
		//
		protected static byte[] m_nBox = new byte[m_nBoxLen];
		//
		// Len of nBox
		//
		static public long m_nBoxLen = 255;
		
		//
		// In Clear Text
		//
		private static string m_sInClearText	= "";
		private static string m_sCryptedText	= "";
		
		#endregion

	}
}
