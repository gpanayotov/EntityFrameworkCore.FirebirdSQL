﻿/*                 
 *                    EntityFrameworkCore.FirebirdSQL
 *     
*
 *              
 *     Permission to use, copy, modify, and distribute this software and its
 *     documentation for any purpose, without fee, and without a written
 *     agreement is hereby granted, provided that the above copyright notice
 *     and this paragraph and the following two paragraphs appear in all copies. 
 * 
 *     The contents of this file are subject to the Initial
 *     Developer's Public License Version 1.0 (the "License");
 *     you may not use this file except in compliance with the
 *     License.
*
 *
 *     Software distributed under the License is distributed on
 *     an "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, either
 *     express or implied.  See the License for the specific
 *     language governing rights and limitations under the License.
 *
 *      Credits: Rafael Almeida (ralms@ralms.net)
 *                              Sergipe-Brazil
 *
 *
 *                              
 *                  All Rights Reserved.
 */

namespace EntityFrameworkCore.FirebirdSQL.Utilities
{
	public enum FbErrorCode
	{
		/* network_error */
		FbErrorNetworkConnection = 335544721,

		/* io_error */
		FbErrorAccessFile = 335544344,

		/* net_connect_err */
		FbErrorEstablishConnection = 335544722
	}
}