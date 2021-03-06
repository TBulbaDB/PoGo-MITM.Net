﻿using Google.Protobuf;
using POGOProtos.Networking.Envelopes;

namespace PoGoMITM.Base.Models
{
    public class POGOProtosResponsePacker : IResponsePacker
    {
        public byte[] GenerateResponseBody(ResponseData responseData)
        {
            var responseEnvelope = new ResponseEnvelope(responseData.ResponseEnvelope) ;
            responseEnvelope.Returns.Clear();
            foreach (var response in responseData.Responses)
            {
                responseEnvelope.Returns.Add(response.Value.ToByteString());
            }

            return responseEnvelope.ToByteArray();
        }
    }
}