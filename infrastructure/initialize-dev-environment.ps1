$resourceGroupName="rg-finance-manager-dev"
$templateFile="./arm/azuredeploy.json"
$templateParameterFile="./arm/azuredeploy.parameters.dev.json"
$deploymentName="initialize-environment"

# Initialization:
# ===============
# Connect-AzAccount
# Set-AzContext [SubscriptionID/SubscriptionName]

New-AzResourceGroupDeployment `
    -ResourceGroupName $resourceGroupName `
    -TemplateFile $templateFile `
    -TemplateParameterFile $templateParameterFile `
    -Name $deploymentName `
    -Mode Complete
    #-Mode Incremental