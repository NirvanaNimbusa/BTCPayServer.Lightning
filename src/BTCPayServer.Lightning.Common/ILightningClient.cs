﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NBitcoin;

namespace BTCPayServer.Lightning
{
    public interface ILightningClient
    {
        Task<LightningInvoice> GetInvoice(string invoiceId, CancellationToken cancellation = default(CancellationToken));
        Task<LightningInvoice> CreateInvoice(LightMoney amount, string description, TimeSpan expiry, CancellationToken cancellation = default(CancellationToken));
        Task<ILightningInvoiceListener> Listen(CancellationToken cancellation = default(CancellationToken));
        Task<LightningNodeInformation> GetInfo(CancellationToken cancellation = default(CancellationToken));
        Task<PayResponse> Pay(string bolt11, CancellationToken cancellation = default(CancellationToken));
        Task<OpenChannelResponse> OpenChannel(NodeInfo destination, Money channelAmount);
        Task<BitcoinAddress> GetDepositAddress();
        Task ConnectTo(NodeInfo nodeInfo);
    }

    public interface ILightningInvoiceListener : IDisposable
    {
        Task<LightningInvoice> WaitInvoice(CancellationToken cancellation);
    }
}