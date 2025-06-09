type ShowAlertFunction = (message: string, type?: string) => void

let showAlertFn: ShowAlertFunction | null = null

export function registerAlert(fn: ShowAlertFunction): void {
  showAlertFn = fn
}

export function showAlert(message: string, type: string = 'success'): void {
  if (showAlertFn) {
    showAlertFn(message, type)
  } else {
    console.warn('Alert não foi registrado.')
  }
}
