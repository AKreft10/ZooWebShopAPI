using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Feautures.Invoices.Commands;

namespace ZooWebShopAPI.Feautures.Invoices.Handlers
{
    public class UploadInvoiceHandler : IRequestHandler<UploadInvoiceCommand, string?>
    {
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;

        public UploadInvoiceHandler(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _mediator = mediator;
        }

        public async Task<string?> Handle(UploadInvoiceCommand request, CancellationToken cancellationToken)
        {
            Cloudinary cloudinary = new Cloudinary(_configuration.GetSection("Cloudinary")["CloudinaryUrl"]);
            cloudinary.Api.Secure = true;

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription($"invoice{Guid.NewGuid()}", new MemoryStream(request.invoice)),
                UseFilename = true,
                UniqueFilename = false,
                Overwrite = true
            };
            var uploadResult = cloudinary.Upload(uploadParams);
            var invoiceUrl = uploadResult.Url.ToString();

            return invoiceUrl;
        }


    }
}
