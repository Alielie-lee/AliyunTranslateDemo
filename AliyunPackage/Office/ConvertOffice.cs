using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.imm.Model.V20170906;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AliyunPackage.Office
{
    /// <summary>
    /// 文档转换
    /// </summary>
    public class ConvertOffice
    {
        public DefaultAcsClient Client;
        public ConvertOffice(string accessKeyId, string accessKeySecret, string region = "cn-hangzhou")
        {
            IClientProfile profile = DefaultProfile.GetProfile(region, accessKeyId, accessKeySecret);
            Client = new DefaultAcsClient(profile);
        }
        /// <summary>
        /// 文档转换（同步）， 同步转换超时时间为5秒，如果转换时间大于5秒的文档转换需要使用异步接口CreateOfficeConversionTask。
        /// </summary>
        /// <param name="project">项目名称。</param>
        /// <param name="srcUri">
        /// <para>源数据的存储位置。</para>
        /// <para>OSS地址规则为oss://bucket/object，其中bucket为和当前项目处于同一区域的OSS Bucket名称，object为文件路径。</para></param>
        /// <param name="tgtUri">转换后输出内容的目标位置，建议TgtUri和SrcUri在同一个OSS Bucket中，便于权限管理。</param>
        /// <param name="tgtType">
        /// <para>转换输出的目标文件类型。包括如下选项：</para>
        /// <para>vector：转换为向量格式的文件，需要使用预览引擎进行渲染后才能预览。</para>
        /// <para>png：转换为PNG格式的图片文件。</para>
        /// <para>jpg：转换为JPG格式的图片文件。</para>
        /// <para>pdf：转换为PDF文件。</para>
        /// <para>text：转换为只包含文本内容的文件，主要用于提取文件的文本内容。只有当源数据类型为演示文档和文字文档时，才支持转换为text格式。</para></param>
        /// <param name="srcType">当OSS对象没有后缀名时，可以设置此参数。源数据的后缀类型。默认根据OSS对象的后缀名确定源数据的类型。</param>
        /// <param name="startPage">文档转换的起始页，默认值为1。</param>
        /// <param name="endPage">文档转换的结束页，默认值为200。如果需要转换所有页，设置此参数为-1。</param>
        /// <param name="maxSheetRow">表格文档转换的最大行数，默认值为1000。如果需要转换所有行，设置此参数为-1</param>
        /// <param name="maxSheetCol">表格文档转换的最大列数，默认值为100。如果需要转换所有列，设置此参数为-1。</param>
        /// <param name="maxSheetCount">表格文档转换的最大Sheet数。如果需要转换所有Sheet，设置此参数为-1。</param>
        /// <param name="sheetOnePage">表格文档转换时，是否将所有Sheet的内容输出到一页。</param>
        /// <param name="modelId">模型ID。此参数暂不可用。</param>
        /// <param name="password">文档的打开密码。如果需要转换有密码的文档，请设置此参数</param>
        /// <param name="tgtFilePrefix">
        /// <para>当TgtType设置为jpg、png、pdf时，此参数才生效。</para>
        /// <para>转换后的文件名称前缀，可以是英文、数字、横划线和下划线，且长度不超过256个字符。</para>
        /// <para>通过设置TgtFilePrefix和TgtFileSuffix，可以实现自定义转换后的文件名称。</para>
        /// <para>如果TgtType设置为jpg，TgtFilePrefix和TgtFileSuffix设置不同时，目标文件的名称规则如下：</para>
        /// <para>当TgtFilePrefix和TgtFileSuffix均为空时，则目标文件的名称为[x].jpg。</para>
        /// <para>当TgtFilePrefix为空，TgtFileSuffix为aa时，则目标文件的名称为[x] aa。</para>
        /// <para> 当TgtFilePrefix为aa，TgtFileSuffix为空时，则目标文件的名称为aa[x]。</para>
        /// <para> 当TgtFilePrefix为aa，TgtFileSuffix为bb时，则目标文件名称为aa[x] bb。</para>
        /// <para>当TgtFilePrefix为aa，TgtFileSuffix为def时，则目标文件名称为aa[x].jpg。</para>
        /// <para>其中[x] 表示多个目标文件，从1开始。如果TgtFilePrefix为aa，TgtFileSuffix为bb，且转换后的文件有3页，则所有的目标文件为aa[1] bb、aa[2] bb、aa[3] bb。</para></param>
        /// <param name="tgtFileSuffix">
        /// <para>当TgtType设置为jpg、png、pdf时，此参数才生效。</para>
        /// <para>转换后的文件名称后缀，可以是英文、数字、横划线和下划线，且长度不超过256个字符。其中def为保留字，表示采用默认的后缀名。</para>
        /// <para>通过设置TgtFilePrefix和TgtFileSuffix，可以实现自定义转换后的文件名称。</para>
        /// <para> 如果TgtType设置为jpg，TgtFilePrefix和TgtFileSuffix设置不同时，目标文件的名称规则如下：</para>
        /// <para>当TgtFilePrefix和TgtFileSuffix均为空时，则目标文件的名称为[x].jpg。</para>
        /// <para>当TgtFilePrefix为空，TgtFileSuffix为aa时，则目标文件的名称为[x] aa。</para>
        /// <para>当TgtFilePrefix为aa，TgtFileSuffix为空时，则目标文件的名称为aa[x]。</para>
        /// <para>当TgtFilePrefix为aa，TgtFileSuffix为bb时，则目标文件名称为aa[x] bb。</para>
        /// <para>当TgtFilePrefix为aa，TgtFileSuffix为def时，则目标文件名称为aa[x].jpg。</para>
        /// <para>其中[x] 表示多个目标文件，从1开始。如果TgtFilePrefix为aa，TgtFileSuffix为bb，且转换后的文件有3页，则所有的目标文件为aa[1] bb、aa[2] bb、aa[3] bb。</para>
        /// </param>
        /// <param name="tgtFilePages">
        /// <para>当TgtType设置为jpg、png、pdf时，此参数才生效。</para>
        /// <para>转换后输出指定文件页数，最多指定100个页数，如果超过100页，请分多次转换进行提交，默认输出所有页。例如当TgtFilePages设置为[1, 2, 100] 时，只会输出第1、2、100页到目标位置。</para>
        /// </param>
        /// <param name="fitToPagesTall">
        /// <para> 当TgtType设置为pdf时，此参数才生效。</para>
        /// <para>表格文档转换为pdf时，将行全部输出到一页，默认值为false。</para>
        /// </param>
        /// <param name="fitToPagesWide">当TgtType设置为pdf时，此参数才生效。表格文档转pdf时，将列全部输出在一页，默认值为false。</param>
        /// <param name="pdfVector">
        /// <para>当PDF转换为VECTOR时，是否使用向量模式，默认值为false。包括如下选项：</para>
        /// <para>true：使用向量模式，预览效果比较清晰，但是转换耗时较长。</para>
        /// <para>false：使用图片模式，预览效果一般，但是转换耗时较短。</para>
        /// </param>
        /// <param name="hidecomments">
        /// <para>当WORD、PPT转换为VECTOR、JPG、PNG时，是否隐藏批注和应用修订，默认值为false。包括如下选项：</para>
        /// <para>true：隐藏批注和应用修订。</para>
        /// <para>false：显示批注和修订。</para>
        /// </param>
        /// <returns></returns>
        public async Task<ConvertOfficeFormatResponse> ConvertOfficeFormatAsync(string project, string srcUri, string tgtUri, string tgtType, string srcType = null, long startPage = 1, long endPage = -1, long maxSheetRow = -1, long maxSheetCol = -1, long maxSheetCount = -1, bool sheetOnePage = false, string modelId = null, string password = null, string tgtFilePrefix = null, string tgtFileSuffix = null, string tgtFilePages = null, bool fitToPagesTall = false, bool fitToPagesWide = false, bool pdfVector = false, bool hidecomments = false)
        {
            var request = new ConvertOfficeFormatRequest()
            {
                Project = project,
                SrcUri = srcUri,
                TgtType = tgtType,
                TgtUri = tgtUri,
                SrcType = srcType,
                StartPage = startPage,
                EndPage = endPage,
                MaxSheetRow = maxSheetRow,
                MaxSheetCol = maxSheetCol,
                MaxSheetCount = maxSheetCount,
                SheetOnePage = sheetOnePage,
                ModelId = modelId,
                Password = password,
                TgtFilePrefix = tgtFilePrefix,
                TgtFileSuffix = tgtFileSuffix,
                TgtFilePages = tgtFilePages,
                FitToPagesTall = fitToPagesTall,
                FitToPagesWide = fitToPagesWide,
                PdfVector = pdfVector,
                Hidecomments = hidecomments
            };
            try
            {

                return await new Task<ConvertOfficeFormatResponse>(() =>
                {
                    return Client.GetAcsResponse(request);
                });
            }
            catch (ServerException e)
            {
                throw e;
            }
            catch (ClientException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 文档转换任务
        /// </summary>
        /// <param name="project">项目名称。</param>
        /// <param name="srcUri">
        /// <para>源数据的存储位置。</para>
        /// <para>OSS地址规则为oss://bucket/object，其中bucket为和当前项目处于同一区域的OSS Bucket名称，object为文件路径。</para></param>
        /// <param name="tgtUri">转换后输出内容的目标位置，建议TgtUri和SrcUri在同一个OSS Bucket中，便于权限管理。</param>
        /// <param name="tgtType">
        /// <para>转换输出的目标文件类型。包括如下选项：</para>
        /// <para>vector：转换为向量格式的文件，需要使用预览引擎进行渲染后才能预览。</para>
        /// <para>png：转换为PNG格式的图片文件。</para>
        /// <para>jpg：转换为JPG格式的图片文件。</para>
        /// <para>pdf：转换为PDF文件。</para>
        /// <para>text：转换为只包含文本内容的文件，主要用于提取文件的文本内容。只有当源数据类型为演示文档和文字文档时，才支持转换为text格式。</para></param>
        /// <param name="srcType">当OSS对象没有后缀名时，可以设置此参数。源数据的后缀类型。默认根据OSS对象的后缀名确定源数据的类型。</param>
        /// <param name="startPage">文档转换的起始页，默认值为1。</param>
        /// <param name="endPage">文档转换的结束页，默认值为200。如果需要转换所有页，设置此参数为-1。</param>
        /// <param name="maxSheetRow">表格文档转换的最大行数，默认值为1000。如果需要转换所有行，设置此参数为-1</param>
        /// <param name="maxSheetCol">表格文档转换的最大列数，默认值为100。如果需要转换所有列，设置此参数为-1。</param>
        /// <param name="maxSheetCount">表格文档转换的最大Sheet数。如果需要转换所有Sheet，设置此参数为-1。</param>
        /// <param name="sheetOnePage">表格文档转换时，是否将所有Sheet的内容输出到一页。</param>
        /// <param name="modelId">模型ID。此参数暂不可用。</param>
        /// <param name="password">文档的打开密码。如果需要转换有密码的文档，请设置此参数</param>
        /// <param name="tgtFilePrefix">
        /// <para>当TgtType设置为jpg、png、pdf时，此参数才生效。</para>
        /// <para>转换后的文件名称前缀，可以是英文、数字、横划线和下划线，且长度不超过256个字符。</para>
        /// <para>通过设置TgtFilePrefix和TgtFileSuffix，可以实现自定义转换后的文件名称。</para>
        /// <para>如果TgtType设置为jpg，TgtFilePrefix和TgtFileSuffix设置不同时，目标文件的名称规则如下：</para>
        /// <para>当TgtFilePrefix和TgtFileSuffix均为空时，则目标文件的名称为[x].jpg。</para>
        /// <para>当TgtFilePrefix为空，TgtFileSuffix为aa时，则目标文件的名称为[x] aa。</para>
        /// <para> 当TgtFilePrefix为aa，TgtFileSuffix为空时，则目标文件的名称为aa[x]。</para>
        /// <para> 当TgtFilePrefix为aa，TgtFileSuffix为bb时，则目标文件名称为aa[x] bb。</para>
        /// <para>当TgtFilePrefix为aa，TgtFileSuffix为def时，则目标文件名称为aa[x].jpg。</para>
        /// <para>其中[x] 表示多个目标文件，从1开始。如果TgtFilePrefix为aa，TgtFileSuffix为bb，且转换后的文件有3页，则所有的目标文件为aa[1] bb、aa[2] bb、aa[3] bb。</para></param>
        /// <param name="tgtFileSuffix">
        /// <para>当TgtType设置为jpg、png、pdf时，此参数才生效。</para>
        /// <para>转换后的文件名称后缀，可以是英文、数字、横划线和下划线，且长度不超过256个字符。其中def为保留字，表示采用默认的后缀名。</para>
        /// <para>通过设置TgtFilePrefix和TgtFileSuffix，可以实现自定义转换后的文件名称。</para>
        /// <para> 如果TgtType设置为jpg，TgtFilePrefix和TgtFileSuffix设置不同时，目标文件的名称规则如下：</para>
        /// <para>当TgtFilePrefix和TgtFileSuffix均为空时，则目标文件的名称为[x].jpg。</para>
        /// <para>当TgtFilePrefix为空，TgtFileSuffix为aa时，则目标文件的名称为[x] aa。</para>
        /// <para>当TgtFilePrefix为aa，TgtFileSuffix为空时，则目标文件的名称为aa[x]。</para>
        /// <para>当TgtFilePrefix为aa，TgtFileSuffix为bb时，则目标文件名称为aa[x] bb。</para>
        /// <para>当TgtFilePrefix为aa，TgtFileSuffix为def时，则目标文件名称为aa[x].jpg。</para>
        /// <para>其中[x] 表示多个目标文件，从1开始。如果TgtFilePrefix为aa，TgtFileSuffix为bb，且转换后的文件有3页，则所有的目标文件为aa[1] bb、aa[2] bb、aa[3] bb。</para>
        /// </param>
        /// <param name="tgtFilePages">
        /// <para>当TgtType设置为jpg、png、pdf时，此参数才生效。</para>
        /// <para>转换后输出指定文件页数，最多指定100个页数，如果超过100页，请分多次转换进行提交，默认输出所有页。例如当TgtFilePages设置为[1, 2, 100] 时，只会输出第1、2、100页到目标位置。</para>
        /// </param>
        /// <param name="fitToPagesTall">
        /// <para> 当TgtType设置为pdf时，此参数才生效。</para>
        /// <para>表格文档转换为pdf时，将行全部输出到一页，默认值为false。</para>
        /// </param>
        /// <param name="fitToPagesWide">当TgtType设置为pdf时，此参数才生效。表格文档转pdf时，将列全部输出在一页，默认值为false。</param>
        /// <param name="pdfVector">
        /// <para>当PDF转换为VECTOR时，是否使用向量模式，默认值为false。包括如下选项：</para>
        /// <para>true：使用向量模式，预览效果比较清晰，但是转换耗时较长。</para>
        /// <para>false：使用图片模式，预览效果一般，但是转换耗时较短。</para>
        /// </param>
        /// <param name="hidecomments">
        /// <para>当WORD、PPT转换为VECTOR、JPG、PNG时，是否隐藏批注和应用修订，默认值为false。包括如下选项：</para>
        /// <para>true：隐藏批注和应用修订。</para>
        /// <para>false：显示批注和修订。</para>
        /// </param>
        /// <param name="idempotentToken">
        /// <para>幂等标识，建议使用UUID格式。不同请求请生成独立的幂等标识。幂等标识的有效期约为43200秒，但不建议复用同一个幂等标识。</para>
        /// <para>当传入幂等标识时，如果两次请求完全一致（包括IdempotentToken本身），则会返回相同结果，即返回相同的TaskId。该功能用于</para>
        /// <para>避免多次执行同样的任务，消耗额外计算资源。</para>
        /// </param>
        /// <param name="displayDpi">当源数据类型转换为JPG、PNG时，此参数才生效。图片分辨率，单位为PPI，取值范围为96 ~2048。</param>
        /// <returns></returns>
        public async Task<CreateOfficeConversionTaskResponse> CreateOfficeConversionTaskAsync(string project, string srcUri, string tgtUri, string tgtType, string srcType = null, long startPage = 1, long endPage = -1, long maxSheetRow = -1, long maxSheetCol = -1, long maxSheetCount = -1, bool sheetOnePage = false, string modelId = null, string password = null, string tgtFilePrefix = null, string tgtFileSuffix = null, string tgtFilePages = null, bool fitToPagesTall = false, bool fitToPagesWide = false, bool pdfVector = false, bool hidecomments = false, string idempotentToken = null, int displayDpi = 0)
        {
            var request = new CreateOfficeConversionTaskRequest()
            {
                Project = project,
                SrcUri = srcUri,
                TgtType = tgtType,
                TgtUri = tgtUri,
                SrcType = srcType,
                StartPage = startPage,
                EndPage = endPage,
                MaxSheetRow = maxSheetRow,
                MaxSheetCol = maxSheetCol,
                MaxSheetCount = maxSheetCount,
                SheetOnePage = sheetOnePage,
                ModelId = modelId,
                Password = password,
                TgtFilePrefix = tgtFilePrefix,
                TgtFileSuffix = tgtFileSuffix,
                TgtFilePages = tgtFilePages,
                FitToPagesTall = fitToPagesTall,
                FitToPagesWide = fitToPagesWide,
                PdfVector = pdfVector,
                Hidecomments = hidecomments,
                IdempotentToken = idempotentToken,
                DisplayDpi = displayDpi,
            };
            try
            {
                return await new Task<CreateOfficeConversionTaskResponse>(() =>
                {
                    return Client.GetAcsResponse(request);
                });

            }
            catch (ServerException e)
            {
                throw e;
            }
            catch (ClientException e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 查询异步文档格式转换任务的状态信息
        /// </summary>
        /// <param name="project">项目名称 从CreateOfficeConversionTask接口设置</param>
        /// <param name="taskId">任务id 从CreateOfficeConversionTask接口获取</param>
        /// <returns></returns>
        public async Task<GetOfficeConversionTaskResponse> GetOfficeConversionTaskAsync(string project, string taskId)
        {

            var request = new GetOfficeConversionTaskRequest()
            {
                Project = project,
                TaskId = taskId,
            };
            try
            {
                return await new Task<GetOfficeConversionTaskResponse>(() =>
                {
                    return Client.GetAcsResponse(request);
                });

            }
            catch (ServerException e)
            {
                throw e;
            }
            catch (ClientException e)
            {
                throw e;
            }
        }
    }

}
